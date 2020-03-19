using System;

namespace OpenDEVCore.Security.Entities
{
    public partial class UserSupervision
    {
        public int IdUserSupervision { get; set; }
        public int IdSupervision { get; set; }
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Supervision IdSupervisionNavigation { get; set; }
    }
}
