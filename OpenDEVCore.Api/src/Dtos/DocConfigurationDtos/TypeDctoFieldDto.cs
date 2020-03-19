using System;
using System.Collections.Generic;

namespace OpenDEVCore.Api.Dtos
{
    public partial class TypeDctoFieldDto
    {
        public int IdTypeDctoField { get; set; }
        public int IdField { get; set; }
        public int IdTypeDocument { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsObligatory { get; set; }
        public bool? IsConstant { get; set; }
        public short? Order { get; set; }
        public string CodeField { get; set; }

        public virtual FieldDto IdFieldNavigation { get; set; }
        public virtual TypeDocumentDto IdTypeDocumentNavigation { get; set; }
    }
}
