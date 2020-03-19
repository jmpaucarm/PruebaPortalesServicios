using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Dto
{
    public partial class TypeDctoFolderDto
    {
        public int IdTypeDctoFolder { get; set; }
        public int IdTypeFolder { get; set; }
        public int IdTypeDocument { get; set; }
        public bool? IndividualSend { get; set; }
        public bool? IsActive { get; set; }
        public short? Order { get; set; }

        public virtual TypeDocumentDto IdTypeDocumentNavigation { get; set; }
        public virtual TypeFolderDto IdTypeFolderNavigation { get; set; }
    }
}
