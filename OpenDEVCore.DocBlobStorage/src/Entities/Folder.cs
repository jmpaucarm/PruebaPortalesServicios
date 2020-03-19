using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class Folder
    {
        public Folder()
        {
            Document = new HashSet<Document>();
            FolderField = new HashSet<FolderField>();
        }

        public int IdFolder { get; set; }
        public string CodeTypeFolder { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int? IdBox { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Box IdBoxNavigation { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<FolderField> FolderField { get; set; }
    }
}
