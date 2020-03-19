using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class DocumentField
    {
        public int IdDocumentField { get; set; }
        public int? IdDocument { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual Document IdDocumentNavigation { get; set; }
    }
}
