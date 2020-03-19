using System;

namespace OpenDEVCore.Security.Entities
{
    public partial class UserProfile
    {
        public int IdUserProfile { get; set; }
        public int? IdProfile { get; set; }
        public int? IdUser { get; set; }
        public int IdOffice { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateUntil { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Profile IdProfileNavigation { get; set; }
    }
}
