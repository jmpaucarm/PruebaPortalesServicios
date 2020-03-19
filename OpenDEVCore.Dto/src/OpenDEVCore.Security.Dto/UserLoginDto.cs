using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Dto
{
    public class UserLoginDto
    {
        public int IdUser { get; set; }
        public int IdInstitution { get; set; }
        public string Institution { get; set; }

        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Email { get; set; }
        public DateTime? PasswordDateMax { get; set; }
        public List<ProfileTransactionsDto> ProfileOfficeTransactions { get; set; }

        public UserLoginDto() { }
        public UserLoginDto(int idUser, 
            int idInstitution,string userCode,string dni, 
            string firstName, string secondName, string lastName1, 
            string lastName2,string email, DateTime? PasswordDateMax)
        {
            IdUser = idUser;
            IdInstitution = idInstitution;
            UserCode = userCode;
            Dni = dni;
            FirstName = firstName;
            SecondName = secondName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Email = email;
            ProfileOfficeTransactions = new List<ProfileTransactionsDto>();
        }

        public void SetInstitution(string institution)
        {
            Institution = institution;
        }
    }
}
