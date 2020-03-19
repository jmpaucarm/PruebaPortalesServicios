using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class WaterMark
    {
        public WaterMark()
        {
            FormVersion = new HashSet<FormVersion>();
        }

        public int IdWaterMark { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public bool IsImage { get; set; }
        public byte[] Image { get; set; }
        public bool? IsActive { get; set; }
        public string Location { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<FormVersion> FormVersion { get; set; }
    }
}