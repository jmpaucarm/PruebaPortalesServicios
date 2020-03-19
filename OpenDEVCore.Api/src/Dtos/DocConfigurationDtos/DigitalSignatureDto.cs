using System;
using System.Collections.Generic;

namespace OpenDEVCore.Api.Dtos
{
    public partial class DigitalSignatureDto
    {

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

        public virtual List<FormVersionDto> FormVersion { get; set; }
    }
}
