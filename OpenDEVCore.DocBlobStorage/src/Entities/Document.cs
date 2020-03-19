using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class Document
    {
        public Document()
        {
            DocumentField = new HashSet<DocumentField>();
            DocumentLog = new HashSet<DocumentLog>();
        }


        public int IdDocument { get; set; }
        public string CodeTypeDocument { get; set; }
        public string Institution { get; set; }
        public string PathDocument { get; set; }
        public DateTime? DateEnd { get; set; }
        public string PathDocumentOrigen { get; set; }
        public bool Iscentralized { get; set; }
        public string PathDocumentFinal { get; set; }
        public byte[] Data { get; set; }
        public int? IdBox { get; set; }
        public int? IdFolder { get; set; }
        public string Type { get; set; }
        public bool? IsVirtual { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        public string CodeDocument { get; set; }
        public bool? IsCopy { get; set; }

        public virtual Folder IdFolderNavigation { get; set; }
        public virtual ICollection<DocumentField> DocumentField { get; set; }
        public virtual ICollection<DocumentLog> DocumentLog { get; set; }
    }
}
