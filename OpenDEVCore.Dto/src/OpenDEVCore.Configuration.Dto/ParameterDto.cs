using Core.General;
using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class ParameterDto : CoreDto
    {
        public int IdParameter { get; set; }
        public string System { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int IntegerValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string TextValue { get; set; }
        public long? DateValue { get; set; }
        public bool? BooleanValue { get; set; }
        public bool? IsInstitution { get; set; }
        public bool? IsEncripted { get; set; }
        public bool? IsActive { get; set; }
    }
}
