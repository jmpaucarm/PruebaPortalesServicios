using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class FolderDocumentDto
    {
        public int IdFolderDocument { get; set; }
        public int? IdFolder { get; set; }
        public int? IdDocument { get; set; }

        public virtual FolderDto IdFolderNavigation { get; set; }
    }
}
