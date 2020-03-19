using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class TypeFolderFieldDto
    {
        public int IdTypeFolderField { get; set; }
        public int IdField { get; set; }
        public int IdTypeFolder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsObligatory { get; set; }
        public bool? IsConstant { get; set; }
        public short? Order { get; set; }
        public string CodeField { get; set; }

        
        public virtual TypeFolderDto IdTypeFolderNavigation { get; set; }
    }
}
