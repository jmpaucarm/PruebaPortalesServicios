using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class Profile
    {
        public Profile()
        {
            InstitutionProfile = new HashSet<InstitutionProfile>();
            ProfileComponent = new HashSet<ProfileComponent>();
            ProfileOption = new HashSet<ProfileOption>();
            UserProfile = new HashSet<UserProfile>();
        }

        public int IdProfile { get; set; }
        public int IdInstitution { get; set; }
        public string ProfileCode { get; set; }
        public string Name { get; set; }
        public string Channel { get; set; }
        public DateTime? DateValidity { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<InstitutionProfile> InstitutionProfile { get; set; }
        public virtual ICollection<ProfileComponent> ProfileComponent { get; set; }
        public virtual ICollection<ProfileOption> ProfileOption { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
