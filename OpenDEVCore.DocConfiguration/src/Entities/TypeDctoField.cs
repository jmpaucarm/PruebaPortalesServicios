using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class TypeDctoField
    {
        public int IdTypeDctoField { get; set; }
        public int IdField { get; set; }
        public int IdTypeDocument { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsObligatory { get; set; }
        public bool? IsConstant { get; set; }
        public short? Order { get; set; }
        public string CodeField { get; set; }

        public virtual Field IdFieldNavigation { get; set; }
        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
    }
}
