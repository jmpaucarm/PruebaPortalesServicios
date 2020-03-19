using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class TypeFolderField
    {
        public int IdTypeFolderField { get; set; }
        public int IdField { get; set; }
        public int IdTypeFolder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsObligatory { get; set; }
        public bool? IsConstant { get; set; }
        public short? Order { get; set; }
        public string CodeField { get; set; }

        public virtual Field IdFieldNavigation { get; set; }
        public virtual TypeFolder IdTypeFolderNavigation { get; set; }
    }
}
