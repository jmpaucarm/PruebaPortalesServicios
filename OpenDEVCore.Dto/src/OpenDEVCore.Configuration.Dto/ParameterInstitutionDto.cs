using System;

namespace OpenDEVCore.Configuration.Dto
{
    public partial class ParameterInstitutionDto
    {
        public int IdParameterInstitution { get; set; }
        public int IdInstitution { get; set; }
        public int IdParameter { get; set; }
        public int IntegerValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string TextValue { get; set; }
        public DateTime? DateValue { get; set; }
        public bool? BooleanValue { get; set; }
        public bool IsActive { get; set; }


    }
}
