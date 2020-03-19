using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class Supervision
    {
        public Supervision()
        {
            UserSupervision = new HashSet<UserSupervision>();
        }

        public int IdSupervision { get; set; }
        public string SupervisionCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsObservation { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<UserSupervision> UserSupervision { get; set; }
    }
}
