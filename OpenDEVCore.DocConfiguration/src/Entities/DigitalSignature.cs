using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class DigitalSignature
    {
        public DigitalSignature()
        {
            FormVersion = new HashSet<FormVersion>();
        }

        public int IdDigitalSignature { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Issuer { get; set; }
        public bool? IsActive { get; set; }
        public byte[] Certificate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<FormVersion> FormVersion { get; set; }
    }
}
