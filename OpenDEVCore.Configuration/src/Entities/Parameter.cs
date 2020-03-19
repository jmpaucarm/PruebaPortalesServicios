using Core.General;
using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Parameter : ICoreEF
    {
        public Parameter()
        {
            ParameterInstitution = new HashSet<ParameterInstitution>();
        }

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
        public bool? IsInstitution { get; set; }
        public bool? IsEncripted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserID { get; set; }
        public int? CreationOfficeID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserID { get; set; }
        public int? UpdateOfficeID { get; set; }

        public virtual ICollection<ParameterInstitution> ParameterInstitution { get; set; }
    }
}
