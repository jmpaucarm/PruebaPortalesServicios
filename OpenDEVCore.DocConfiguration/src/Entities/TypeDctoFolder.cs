using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class TypeDctoFolder
    {
        public int IdTypeDctoFolder { get; set; }
        public int IdTypeFolder { get; set; }
        public int IdTypeDocument { get; set; }
        public bool? IndividualSend { get; set; }
        public bool? IsActive { get; set; }
        public short? Order { get; set; }

        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
        public virtual TypeFolder IdTypeFolderNavigation { get; set; }
    }
}
