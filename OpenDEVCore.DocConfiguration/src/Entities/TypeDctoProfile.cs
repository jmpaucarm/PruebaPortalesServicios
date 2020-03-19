using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class TypeDctoProfile
    {
        public int IdTypeDctoProfile { get; set; }
        public int? IdTypeDocument { get; set; }
        public int? IdProfile { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? IsRePrinted { get; set; }
        public bool? IsActive { get; set; }

        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
    }
}
