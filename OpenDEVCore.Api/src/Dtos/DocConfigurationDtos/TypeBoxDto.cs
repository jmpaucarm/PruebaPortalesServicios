using System;
using System.Collections.Generic;

namespace OpenDEVCore.Api.Dtos
{
    public partial class TypeBoxDto
    {

        public int IdTypeBox { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual List<TypeBoxFieldDto> TypeBoxField { get; set; }
    }
}
