using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class FolderField
    {
        public int IdFolderField { get; set; }
        public int? IdFolder { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual Folder IdFolderNavigation { get; set; }
    }
}
