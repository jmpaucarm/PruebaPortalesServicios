using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenDEVCore.Security.Dto;

using Sodium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenDEVCore.Security.Entities
{
    public partial class User 
    {
        private readonly IMapper _mapper;
        public User(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add(AddUserDto cmnd)
        {
             PasswordDateMax = DateTime.Now.Date; //FECHA DE CAMBIO DE PASSWORD
        }

        public void Edit(User editUser)
        {
            // para el tema de fechas lo tomo de el mapear convertido
            //var editUser = _mapper.Map<User>(cmnd);

            FirstName = editUser.FirstName;
            SecondName = editUser.SecondName;
            LastName1 = editUser.LastName1;
            LastName2 = editUser.LastName2;
            CellPhone = editUser.CellPhone;
            Email = editUser.Email;
            CtlgState = editUser.CtlgState;
            IsActive = editUser.IsActive;
            Observation = editUser.Observation;
            InactivityType = editUser.InactivityType;
            
            DateFrom = editUser.DateFrom;
            DateUntil = editUser.DateUntil;

            DateStartInactivity = editUser.DateStartInactivity;
            DateEndInactivity = editUser.DateEndInactivity;
            
            // actualización de registros de perfiles
            foreach (var profile in UserProfile)
            {
                var profiletmp = editUser.UserProfile.Where(q => q.IdUserProfile == profile.IdUserProfile).FirstOrDefault();
                profile.IdOffice = profiletmp.IdOffice;
                profile.IdProfile = profiletmp.IdProfile;
                profile.DateFrom = profiletmp.DateFrom;
                profile.DateUntil = profiletmp.DateUntil;
                profile.IsActive = profiletmp.IsActive;
                profile.UpdateDate = DateTime.Now;
            }

            // creación de registros nuevos de perfiles
            List<UserProfile> newProfiles = editUser.UserProfile.Where(x => x.IdUserProfile == 0).ToList();
            foreach (UserProfile x in newProfiles)
            {
                UserProfile.Add(new UserProfile
                {
                    IdUser = editUser.IdUser,
                    IdProfile = x.IdProfile,
                    IdOffice = x.IdOffice,
                    DateFrom = x.DateFrom,
                    DateUntil = x.DateUntil,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                });

                }
            }
        private string CreateRandomPassword()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, new Random().Next(8, 10)).Select(x => input[rand.Next(0, input.Length)]).ToArray()); //xxx Crear clave encriptada
        }

        
        public string SetPassword(IPasswordHasher<User> passwordHasher, DateTime fechaVigencia)
        {
            //Password = PasswordHash.ScryptHashString(CreateRandomPassword(), PasswordHash.Strength.Medium);
            var randomPassword = CreateRandomPassword().ToUpper();
            Password = passwordHasher.HashPassword(this, randomPassword);
            PasswordDateMax = fechaVigencia;

            Disconnect();
            return randomPassword;
        }

        public void ChangePassword(string newPassword ,IPasswordHasher<User> passwordHasher)
        {
            Password = PasswordHash.ScryptHashString(newPassword);
            //Password = passwordHasher.HashPassword(this, newPassword);
            NumberAccessError = 0;
            UpdateDate = DateTime.Now;
        }

        public bool ValidatePassword(string currentPassword, string inputPassword)
        {
            //var pass = PasswordHash.ScryptHashString(inputPassword);
            return PasswordHash.ScryptHashStringVerify(currentPassword, inputPassword);
        }


        //public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
        //  => passwordHasher.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;

        public void Disconnect()
        {
            CtlgState = "DESC";
            NumberAccessError = 0;
            UpdateDate = DateTime.Now;
        }
        public  void Connect(string station)
        {
            PcName = station;
            CtlgState = "CON";
            NumberAccessError = 0;
            UpdateDate = DateTime.Now;
            DateLastAccess = DateTime.Now;
        }

        public void Lock(string station)
        {
            CtlgState = "BLOQ";
            DateLastAccess = DateTime.Now;
            NumberAccessError = NumberAccessError ++;
            PcName = station;
            UpdateDate = DateTime.Now;
        }
    }
}
