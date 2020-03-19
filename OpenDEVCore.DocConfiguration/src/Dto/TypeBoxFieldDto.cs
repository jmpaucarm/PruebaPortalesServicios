using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Dto
{
    public partial class TypeBoxFieldDto
    {
        public int IdTypeBoxField { get; set; }
        public int IdField { get; set; }
        public int IdTypeBox { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsObligatory { get; set; }
        public bool? IsConstant { get; set; }
        public short? Order { get; set; }
        public string CodeField { get; set; }

        public virtual FieldDto IdFieldNavigation { get; set; }
        public virtual TypeBoxDto IdTypeBoxNavigation { get; set; }
    }
}
