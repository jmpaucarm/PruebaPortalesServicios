using System;
using System.Collections.Generic;

namespace OpenDEVCore.Api.Dtos
{
    public partial class TypeDctoProfileDto
    {
        public int IdTypeDctoProfile { get; set; }
        public int? IdTypeDocument { get; set; }
        public int? IdProfile { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? IsRePrinted { get; set; }
        public bool? IsActive { get; set; }

        public virtual TypeDocumentDto IdTypeDocumentNavigation { get; set; }
    }
}
