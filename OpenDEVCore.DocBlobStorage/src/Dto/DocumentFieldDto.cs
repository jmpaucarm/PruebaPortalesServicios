using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class DocumentFieldDto
    {
        public int IdDocumentField { get; set; }
        public int? IdDocument { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual DocumentDto IdDocumentNavigation { get; set; }
    }
}
