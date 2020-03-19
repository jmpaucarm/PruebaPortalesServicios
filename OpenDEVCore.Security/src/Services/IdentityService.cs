using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Timer;
using Core.Authentication;
using Core.General;
using Core.Mvc;
using Core.RabbitMq;
using Core.Types;
using Core.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Helpers;
using OpenDEVCore.Security.Proxy;
using OpenDEVCore.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Services
{
    public class IdentityService : BaseService, IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IConfigurationService _configurationService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IJwtHandler _jwtHandler;
        private readonly IProfileComponentRepository _IProfileComponentRepository;
        private readonly ILogger<IdentityService> _logger;
        private readonly IMetrics _metrics;
        private readonly IProfileRepository _IProfileRepository;

        public IdentityService(
            IUserRepository userRepository,
            ISecurityRepository securityRepository,
            IConfigurationService configurationService, //interface de proxy
            IClaimsProvider claimsProvider,
            IPasswordHasher<User> passwordHasher,
            IJwtHandler jwtHandler,
            ILogger<IdentityService> logger,
             IMetrics metrics,
             IProfileComponentRepository iProfileComponentRepository,
             IProfileRepository IProfileRepository

           ) : base(configurationService) //se envía como parámetro al constructor de la clase base.
        {
            _userRepository = userRepository;
            _securityRepository = securityRepository;
            _configurationService = configurationService;
            _claimsProvider = claimsProvider;
            _passwordHasher = passwordHasher;
            _jwtHandler = jwtHandler;
            _IProfileComponentRepository = iProfileComponentRepository;
            _logger = logger;
            _metrics = metrics;
            _IProfileRepository = IProfileRepository;
        }

        public async Task<bool> MetricsLogAsync(string userCode)
        {
            var signCounter = new CounterOptions
            {
                Name = "Sign in Counter",
                MeasurementUnit = Unit.Calls
            };
            _metrics.Measure.Counter.Increment(signCounter);

            var requestTimer = new TimerOptions
            {
                Name = "Sign in Timer",
                MeasurementUnit = Unit.Requests,
                DurationUnit = TimeUnit.Milliseconds,
                RateUnit = TimeUnit.Milliseconds
            };

            using (_metrics.Measure.Timer.Time(requestTimer))
            {
                await Task.Delay(2000);
            }

            //guardo log general
            _logger.LogInformation("Trx Login {user}", "prueba");

            return true;

        }

        public async Task<object> SignInAsync(string userCode, string password, string station)
        {
            var user = await _userRepository.GetAsync(userCode);

            if (user == null)
            {
                SaveLog(station, 0, userCode, "NOEXIST", "SignIn");
                throw new CoreException(ExMessages.UserDoesNotExists);
            }

            if (user.IsActive == false)
            {
                SaveLog(station, user.IdUser, user.UserCode, "INACTIVO", "SignIn");
                throw new CoreException(ExMessages.UserIsNotActive);
            }

            if (user.CtlgState == "BLOQ")
            {
                SaveLog(station, user.IdUser, user.UserCode, "BLOQ", "SignIn");
                throw new CoreException(ExMessages.UserIsBlocked);
            }
            
            if (user.CtlgState == "CON" && user.PcName.ToLower() != station.ToLower())
            {
                SaveLog(station, user.IdUser, user.UserCode, "USR CONECTADO", "SignIn");
                throw new CoreException(ExMessages.UserIsConnectedInAnotherTerminal);
            }

            //if (user.PasswordDateMax <= DateTime.Now)
            //{
            //    SaveLog(station, user.IdUser, user.UserCode, "CLAVE CADUCADA", "SignIn");
            //    throw new CoreException(ExMessages.UserDatePassword);
            //}


            if (!user.ValidatePassword(user.Password, password))
            {
                //BlockUser(userCode);
                var parameterResponse = await _configurationService.GetParameter("NUMBERATTEMPS", 0);

                if (!parameterResponse.state)
                    throw new CoreException();

                var parameter = parameterResponse.Get();

                if (user.NumberAccessError + 1 >= parameter.IntegerValue) // si supera el numero de intentos nbloquea
                {
                    user.Lock(station);
                }

                user.NumberAccessError++; //incremeta el numero de intentos
                _userRepository.Edit(user);

                //commit en la base de datos
                await _securityRepository.SaveAsync();


                if (user.CtlgState == "BLOQ")
                {
                    SaveLog(station, user.IdUser, user.UserCode, "BLOQ", "SignIn");
                    throw new CoreException(ExMessages.UserBlocked);
                }
                else
                {
                    int intentos = parameter.IntegerValue - user.NumberAccessError;
                    SaveLog(station, user.IdUser, user.UserCode, "PASS INCORRECTO", "SignIn");
                    throw new CoreException(ExMessages.UsersPasswordIncorrect.code, $"¡Clave incorrecta!, le quedan '{intentos}' intentos");
                }
            }

            //genera el registro del usuario en el dto
            var userLogin = new UserLoginDto(user.IdUser, user.IdInstitution, user.UserCode, user.Dni, user.FirstName, user.SecondName, user.LastName1, user.LastName2, user.Email, user.PasswordDateMax);

            //Obtiene el nombre de la institucion
            var institutionResponse = await _configurationService.GetInstitutionById(userLogin.IdInstitution);

            var institution = institutionResponse.Get();
            userLogin.SetInstitution(institution.Name);//setea el nombre de la institucion


            foreach (UserProfile userProfile in user.UserProfile)
            {
                if (userProfile.IsActive && userProfile.IdProfileNavigation.IsActive)
                {
                    List<MenuOptionDto> transactions = new List<MenuOptionDto>();
                    transactions = _userRepository.GetByUserProfileOffice(userProfile.IdUser, userProfile.IdProfile, userProfile.IdOffice);

                    ProfileTransactionsDto optionsUser = new ProfileTransactionsDto(userProfile.IdProfile, "Nombre Oficina", userProfile.IdOffice, userProfile.IdProfileNavigation.ProfileCode, userProfile.IdProfileNavigation.Name, transactions);
                    userLogin.ProfileOfficeTransactions.Add(optionsUser);
                }
            }

            //Consultar Oficinas para presentar en pantalla
            var ids = user.UserProfile.Where(x => x.IsActive).Select(x => x.IdOffice).Distinct().ToArray();
            var offices = (await _configurationService.GetOffices(ids)).Get();

            ////Armar El objeto de respuesta
            var resultObject = new
            {
                userLogin = userLogin,
                singInResult = true,
                offices = offices.Select(p => new
                {
                    code = p.IdOffice,
                    description = p.Name,
                    profiles = user.UserProfile
                    .Where(xx => xx.IdOffice.Equals(p.IdOffice) && xx.IsActive)
                    .Distinct()
                    .Select(q => new
                    {
                        idProfile = q.IdProfile,
                        description = q.IdProfileNavigation.Name,
                        code = q.IdProfileNavigation.ProfileCode
                    }).ToList(),
                }).ToList()
            };

            //crea el registro del log
            SaveLog(station, user.IdUser, user.UserCode, "SIGNIN", "Authentication OK");

            return resultObject;
        }
        public async Task<object> SignInFromPortalAsync(string encodedCredentials, string station)
        {
            //encodedCredentials = Convert.ToBase64String(StringToByteArray(encodedCredentials));
            var credentials = Cipher.DecryptKW(encodedCredentials);
            var arr = credentials.Split(';');
            if(arr.Length > 1)
                return await SignInAsync(arr[0], arr[1], station);
            else
                return null;
        }

        public async Task SignOutAsync(string userCode)
        {
            var user = await _userRepository.GetAsync(userCode);

            //setea al usuario como desconectado
            user.Disconnect();
            _userRepository.Edit(user);

            //commit en la base de datos
            await _securityRepository.SaveAsync();

            //crea el registro del log
            SaveLog("Station", user.IdUser, user.UserCode, "SINGOUT", "SingOut");

        }
        public async Task<bool> ChangePasswordAsync(string userCode, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(userCode);

            if (!user.ValidatePassword(user.Password, currentPassword))
            {
                throw new CoreException(ExMessages.UsersPasswordIncorrect);
            }

            //cambia el password
            user.ChangePassword(newPassword, _passwordHasher);
            _userRepository.Edit(user);

            ////commit en la base de datos
            var result = await _securityRepository.SaveAsync();

            //crea el registro del log
            SaveLog("Station", user.IdUser, user.UserCode, "PASSWORD", "Changed Password");

            return result;
        }

        public async Task<object> ConnectAsync(string userCode, int office, int profile, string profileCode, string station)
        {
            var user = await _userRepository.GetAsync(userCode);
            //establece al usuario como conectado
            user.Connect(station);
            _userRepository.Edit(user);

            // si valida todo genera le token
            var refreshToken = new RefreshToken(user, _passwordHasher);
            var claims = await _claimsProvider.GetAsync(Guid.NewGuid());
            Profile profileC = profileC = await _IProfileRepository.GetByCodeAsync(profileCode);
            List<ProfileComponent> profileComponents;
            if (profile < 1)
            {
                profileComponents = await _IProfileComponentRepository.GetProfileComponentsByProfileCode(profileCode);
                if (profileComponents.Count > 0)
                    profile = profileComponents.First().IdProfile;
                else
                    profile = profileC.IdProfile;

            }
            else
                profileComponents = await _IProfileComponentRepository.GetProfileComponentsByProfileId(profile);

            var privileges = (profileComponents)
                .Select(p => p.IdComponentNavigation.IdOptionNavigation)
                .Distinct()
                .Select(x => new
                {
                    View = x.View,
                    Components = x.Component.Select(y => new
                    {
                        ComponentName = y.ComponentName,
                        Disabled = y.Disabled,
                        Hidden = y.Hidden,
                    })
                });


            //Obtiene el nombre de la institucion
            InstitutionDto institution = (await _configurationService.GetInstitutionById(user.IdInstitution)).Get();

            var offices = (await _configurationService.GetOffices(new int[] { office })).Get();


            ////Armar El objeto de oficinas
            var officesLocal = offices.Select(p => new
            {
                code = p.IdOffice,
                description = p.Name,
                profiles = user.UserProfile
                    .Where(xx => xx.IdOffice.Equals(p.IdOffice) && xx.IdProfile.Equals(profile))
                    .Distinct()
                    .Select(q => new
                    {
                        idProfile = q.IdProfile,
                        description = q.IdProfileNavigation.Name,
                        code = q.IdProfileNavigation.ProfileCode
                    }).ToList(),
            }).ToList();

            List<ProfileTransactionsDto> profileTransactions = new List<ProfileTransactionsDto>();
            var profileLocal = user.UserProfile.FirstOrDefault(xx => xx.IdOffice.Equals(office) && xx.IdProfile.Equals(profile));
            if (profileLocal != null && profileLocal.IsActive && profileLocal.IdProfileNavigation.IsActive)
            {
                List<MenuOptionDto> transactions = new List<MenuOptionDto>();
                transactions = _userRepository.GetByUserProfileOffice(profileLocal.IdUser, profileLocal.IdProfile, profileLocal.IdOffice);

                ProfileTransactionsDto optionsUser = new ProfileTransactionsDto(profileLocal.IdProfile, "Nombre Oficina", profileLocal.IdOffice, profileLocal.IdProfileNavigation.ProfileCode, profileLocal.IdProfileNavigation.Name, transactions);
                profileTransactions.Add(optionsUser);
            }

            //claims.Add(ClaimTypes.Email, user.Email);
            
            claims.Add(nameof(UserSession.UserID), user.IdUser.ToString());
            claims.Add(nameof(UserSession.UserCode), user.UserCode.ToString());

            claims.Add(nameof(UserSession.ProfileID), profile.ToString());
            claims.Add(nameof(UserSession.ProfileCode), profileCode);
            claims.Add(nameof(UserSession.ProfileName), (profileComponents.Count > 0) ?
                profileComponents.First().IdProfileNavigation.Name :
            profileC.Name);

            claims.Add(nameof(UserSession.InstitutionID), user.IdInstitution.ToString());
            claims.Add(nameof(UserSession.InstitutionName), institution.Name + string.Empty);
            claims.Add(nameof(UserSession.InstitutionCode), institution.Code );
            claims.Add(nameof(UserSession.InstitutionIsOwner), institution.IsOwner.ToString());

            claims.Add(nameof(UserSession.OfficeID), office.ToString());
            claims.Add(nameof(UserSession.OfficeName), offices.Count > 0 ? offices.First().Name + string.Empty : string.Empty);
            claims.Add(nameof(UserSession.FullName), String.Format("{0} {1} {2} {3}", user.FirstName, user.SecondName, user.LastName1, user.LastName2));
            claims.Add(nameof(UserSession.SimpleName), String.Format("{0} {1}", user.FirstName, user.LastName1));


            //obtienen la fecha del sistema
            var parameterResponse = await _configurationService.GetParameter("SYSTEMDATE", 0);

            if (!parameterResponse.state)
                throw new CoreException();

            var parameter = parameterResponse.Get();

            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var varDate = dtDateTime.AddSeconds(parameter.DateValue.Value).ToLocalTime().Date;

           
            claims.Add(nameof(UserSession.DateSystem), varDate.ToString("yyyy-MM-dd")); // cambiar por la fecha del sistema

            claims.Add(nameof(UserSession.StationIp), station);

            var jwt = _jwtHandler.CreateToken(Guid.NewGuid().ToString(), claims: claims);

            jwt.RefreshToken = refreshToken.Token;
            // await _refreshTokenRepository.AddAsync(refreshToken);

            ////commit en la base de datos
            await _securityRepository.SaveAsync();
            // guarda un log de conexcion
            SaveLog("Station", user.IdUser, user.UserCode, "CONNECT", "Usuario Conectado");

            var resultConnect = new
            {
                jwt = jwt,
                privileges = JsonConvert.SerializeObject(privileges, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                }),
                profileTransactions = JsonConvert.SerializeObject(profileTransactions, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                })
            };

            return resultConnect;
        }
        private void SaveLog(string station, int idUser, string userCode, string evento, string comment)
        {
            _logger.LogInformation($"{station} {idUser} {userCode} {evento} {comment}");
        }
        private byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
