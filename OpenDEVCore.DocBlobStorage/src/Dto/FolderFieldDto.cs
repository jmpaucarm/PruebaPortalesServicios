using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class FolderFieldDto
    {
        public int IdFolderField { get; set; }
        public int? IdFolder { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual FolderDto IdFolderNavigation { get; set; }
    }
}
