using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class ParametherDto : CoreDto
    {
        public int IdParameter { get; set; }
        public string System { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int IntegerValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string TextValue { get; set; }
        public DateTime? DateValue { get; set; }
        public bool? BooleanValue { get; set; }
        public bool IsActive { get; set; }
        public bool? IsInstitution { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        public List<ParameterInstitutionDto> CatalogueDetail { get; set; }
    }
}
