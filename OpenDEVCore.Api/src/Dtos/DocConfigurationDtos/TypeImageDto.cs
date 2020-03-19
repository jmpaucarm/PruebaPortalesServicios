using System;
using System.Collections.Generic;

namespace OpenDEVCore.Api.Dtos
{
    public partial class TypeImageDto
    {
        public int IdTypeImage { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public bool? IsDuplex { get; set; }
        public bool? MultiPages { get; set; }
        public bool? VariablesPages { get; set; }
        public short? NumberPages { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
    }
}
