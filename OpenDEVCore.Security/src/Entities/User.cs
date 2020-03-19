using Core.General;
using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class User : ICoreEF

    {
        public User()
        {
        }

        public int IdUser { get; set; }
        public int IdInstitution { get; set; }
        public string UserCode { get; set; }
        public string IdentificationType { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateUntil { get; set; }
        public string CtlgState { get; set; }
        public bool? IsActive { get; set; }
        public string InactivityType { get; set; }
        public DateTime? DateStartInactivity { get; set; }
        public DateTime? DateEndInactivity { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordDateMax { get; set; }
        public string Observation { get; set; }
        public DateTime? DateLastAccess { get; set; }
        public string PcName { get; set; }
        public short NumberAccessError { get; set; }
        public string UserHomologation { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        //public virtual ICollection<UserPassword> UserPassword { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        public virtual ICollection<UserSupervision> UserSupervision { get; set; }
    }
}
