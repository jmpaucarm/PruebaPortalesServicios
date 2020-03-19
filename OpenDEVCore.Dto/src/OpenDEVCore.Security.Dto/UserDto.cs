using System.Collections.Generic;

namespace OpenDEVCore.Security.Dto
{
    public class UserDto
    {
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
        public long DateFrom { get; set; }
        public long? DateUntil { get; set; }
        public string CtlgState { get; set; }
        public bool? IsActive { get; set; }
        //public string Password { get; set; }
        public long PasswordDateMax { get; set; }
        public string Observation { get; set; }
        public long DateLastAccess { get; set; }
        public string PcName { get; set; }
        public short NumberAccessError { get; set; }
        public string UserHomologation { get; set; }
        public long CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public long UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        public string InactivityType { get; set; }
        public long? DateStartInactivity { get; set; }
        public long? DateEndInactivity { get; set; }
        public List<UserProfileDto> UserProfile { get; set; }
    }
}
