using System.Collections.Generic;

namespace OpenDEVCore.Security.Dto
{
    public class ProfileDto
    {
        public int IdProfile { get; set; }
        public int IdInstitution { get; set; }
        public string ProfileCode { get; set; }
        public string Name { get; set; }
        public string Channel { get; set; }
        public long? DateValidity { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsActive { get; set; }
        public List<ProfileOptionDto> ProfileOption { get; set; }
    }
}
