using AutoMapper;
using Core.RabbitMq;
using Core.Types;
using Microsoft.AspNetCore.Identity;

using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Messages.Events;
using OpenDEVCore.Security.Queries;
using OpenDEVCore.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenDEVCore.Security.Proxy;
using OpenDEVCore.Security.Helpers;
using Core.Mvc;

namespace OpenDEVCore.Security.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly ILogSecurityRepository _logSecurityRepository;
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;


        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            IBusPublisher busPublisher,
            IUserRepository userRepository,
            ISecurityRepository securityRepository,
            ILogSecurityRepository logSecurityRepository,
            IPasswordHasher<User> passwordHasher,
            IConfigurationService configurationService,
            IMapper mapper
           ) : base(configurationService)
        {
            _busPublisher = busPublisher;
            _userRepository = userRepository;
            _securityRepository = securityRepository;
            _logSecurityRepository = logSecurityRepository;
            _passwordHasher = passwordHasher;
            _configurationService = configurationService;
            _mapper = mapper;

        } 

        public async Task<UserDto> GetAsync(UserGeneral query)
        {
            var user = await _userRepository.GetAsync(query.UserCode);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<bool> FindAsync(UserGeneral query)
        {
            var user = await _userRepository.FindAsync(query.UserCode);
            return user;
        }

        public async Task<PagedResult<UserDto>> BrowseAllAsync(BrowseAllUsers query)
        {

            var pagedResult = await _userRepository.BrowseAllAsync(query);
            var users = pagedResult.Items.Select(c => new UserDto
            {
                IdUser = c.IdUser,
                IdInstitution = c.IdInstitution,
                UserCode = c.UserCode,
                IdentificationType = c.IdentificationType,
                Dni = c.Dni,

                FirstName = c.FirstName,
                SecondName = c.SecondName,
                LastName1 = c.LastName1,
                LastName2 = c.LastName2,
                CellPhone = c.CellPhone,
                Email = c.Email,
                CtlgState = c.CtlgState,
                IsActive = c.IsActive,
                Observation = c.Observation,
                InactivityType = c.InactivityType,

                DateFrom = c.DateFrom.HasValue ? new DateTimeOffset(c.DateFrom.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,

                DateUntil = c.DateUntil.HasValue ? new DateTimeOffset(c.DateUntil.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,

                DateStartInactivity = c.DateStartInactivity.HasValue ? new DateTimeOffset(c.DateStartInactivity.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,
                DateEndInactivity = c.DateEndInactivity.HasValue ? new DateTimeOffset(c.DateEndInactivity.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,

            });

            return PagedResult<UserDto>.From(pagedResult, users);
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            List<UserDto> listUsers = new List<UserDto>();
            foreach (User u in users)
            {
                listUsers.Add(new UserDto
                {

                    IdUser = u.IdUser,
                    IdInstitution = u.IdInstitution,
                    UserCode = u.UserCode,
                    IdentificationType = u.IdentificationType,
                    Dni = u.Dni,

                    FirstName = u.FirstName,
                    SecondName = u.SecondName,
                    LastName1 = u.LastName1,
                    LastName2 = u.LastName2,
                    CellPhone = u.CellPhone,
                    Email = u.Email,
                    CtlgState = u.CtlgState,
                    IsActive = u.IsActive,
                    Observation = u.Observation,
                    InactivityType = u.InactivityType,

                    DateFrom = u.DateFrom.HasValue ? new DateTimeOffset(u.DateFrom.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,

                    DateUntil = u.DateUntil.HasValue ? new DateTimeOffset(u.DateUntil.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,

                    DateStartInactivity = u.DateStartInactivity.HasValue ? new DateTimeOffset(u.DateStartInactivity.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,
                    DateEndInactivity = u.DateEndInactivity.HasValue ? new DateTimeOffset(u.DateEndInactivity.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds() : 0,
                });
            };
            return listUsers;
        }

        public async Task<bool> EditAsync(EditUserDto userDto)
        {

            //PARA PASAR LA SESSION A OTRO SERVICIO 
            //var ss = _httpContextAccessor.GetSession();
            //var paramether = await _configurationService.GetParamether("SYSTEMDATE",ss);
            //DateTime? fecha = paramether.DateValue;

            var exist = await _userRepository.FindAsync(userDto.UserCode);

            if (!exist) //valida que usuario no exista
                throw new CoreException(ExMessages.UserDoesNotExists);

            //modifica los datos del registro
            User user = await _userRepository.GetAsync(userDto.UserCode);

            user.Edit(_mapper.Map<User>(userDto));
            _userRepository.Edit(user);

            //commit en la base de datos
            await _securityRepository.SaveAsync();

            // guarda el log se seguridad
            await _busPublisher.SendAsync(new LogSecurityCommand("Edit", user.IdUser, user.UserCode, 0, "Edición usuario", "station"), CorrelationContext.FromId(Guid.NewGuid()));

            return true;
        }

        public async Task<int> AddAsync(AddUserDto userDto)
        {
            var exist = await _userRepository.FindAsync(userDto.UserCode);

            if (exist) //valida que usuario no exista
                throw new CoreException(ExMessages.UserAllreadyExists);

            //saco la fecha de la sessión
            var dateSystem = _userSession.DateSystem;

            //crea el registro del usuario
            var newUser = _mapper.Map<Entities.User>(userDto);
            newUser.Add(userDto);
            var password = newUser.SetPassword(_passwordHasher, dateSystem); //devuelve el password generado para ser envia al mail
            await _userRepository.AddAsync(newUser);

            //commit en la base de datos
            await _securityRepository.SaveAsync();

            ////notifica el mail
            var names = userDto.FirstName + " " + userDto.LastName1;
            await _busPublisher.PublishAsync(new UserCreated(userDto.IdUser, userDto.UserCode, names, userDto.Email, password, dateSystem), CorrelationContext.FromId(new Guid()));

            // cred un log del usuario
            await _busPublisher.SendAsync(new LogSecurityCommand("Add", newUser.IdUser, newUser.UserCode, 0, "Creación usuario", "station"), CorrelationContext.FromId(Guid.NewGuid()));


            //retorna el id del usuario
            return newUser.IdUser;
        }

        public async Task<UserLoginDto> GetUserProfilesAsync(UserGeneral userDto)//, string userCode, string password, string station, UserSession userSession)
        {
            var user = await _userRepository.GetAsync(userDto.UserCode);

            //genera el registro del usuario en el dto
            var userLogin = new UserLoginDto(user.IdUser, user.IdInstitution, user.UserCode, user.Dni, user.FirstName, user.SecondName, user.LastName1, user.LastName2, user.Email, user.PasswordDateMax);

            //Obtiene el nombre de la institucion
            var institutionResponse = await _configurationService.GetInstitutionById(userLogin.IdInstitution);

            if (!institutionResponse.state)
                throw new CoreException();

            var institution = institutionResponse.Get();
            userLogin.SetInstitution(institution.Name);//setea el nombre de la institucion

            //genera los registros de perfiles
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
            //retorna el objeto de usuario 
            return userLogin;
        }

        public async Task UnLockAsync(UnLock cmnd)
        {
            var user = await _userRepository.GetAsync(cmnd.UserCode);

            //saco la fecha de la sessión
            var dateSystem = _userSession.DateSystem;

            //reserteo de password
            var password = user.SetPassword(_passwordHasher, dateSystem); //devuelve el password generado para ser envia al mail
            _userRepository.Edit(user);

            //commit en la base de datos
            await _securityRepository.SaveAsync();

            // cred un log del usuario
            await _busPublisher.SendAsync(new LogSecurityCommand("UnLock", user.IdUser, user.UserCode, 0, "UnLock User", "station"), CorrelationContext.FromId(Guid.NewGuid()));

            //notifica el mail
            var names = user.FirstName + " " + user.LastName1;
            await _busPublisher.PublishAsync(new UserCreated(user.IdUser, user.UserCode, names, user.Email, password, dateSystem), CorrelationContext.FromId(new Guid()));
        }
        public async Task DisconnectAsync(DisconnectUser cmnd)
        {
            var user = await _userRepository.GetAsync(cmnd.UserCode);

            //desconecto al usurios
            user.Disconnect();
            _userRepository.Edit(user);

            //commit en la base de datos
            await _securityRepository.SaveAsync();

            // cred un log del usuario
            await _busPublisher.SendAsync(new LogSecurityCommand("DISCONNECTED", user.IdUser, user.UserCode, 0, "Desconexión de usuario", "station"), CorrelationContext.FromId(Guid.NewGuid()));
        }

        //public async Task LockUserAsync(LockUserCommand cmnd)
        //{
        //    var user = await _userRepository.GetAsync(cmnd.UserCode);

        //    var paramether = await _configurationService.GetParamether("NUMBERATTEMPS", "");

        //    if (user.NumberAccessError + 1 >= paramether.IntegerValue) // si supera el numero de intentos nbloquea
        //    {
        //        user.Lock(cmnd.Station);
        //        // cred un log del usuario
        //        await _busPublisher.SendAsync(new LogSecurityCommand("LOCK", user.IdUser, user.UserCode, 0, "BLOQUEO", "station"), CorrelationContext.FromId(Guid.NewGuid()));
        //    }

        //    user.NumberAccessError++; //incremeta el numero de intentos
        //    _userRepository.Edit(user);

        //    //commit en la base de datos
        //    await _securityRepository.SaveAsync();

        //}

        public async Task AddLogSecurityAsync(LogSecurityCommand log)
        {
            //registro del log
            var newLog = new LogSecurity(log.IdUser, log.UserCode, log.Event, log.Observation);
            await _logSecurityRepository.AddAsync(newLog);

            //commit en la base de datos
            await _securityRepository.SaveAsync();
        }

        public Task LockUserAsync(LockUserCommand cmnd)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetByIds(int[] ids)
        {
            var users = await _userRepository.GetByIds(ids);
            return users == null ? null : _mapper.Map<List<UserDto>>(users);
        }
    }
}
