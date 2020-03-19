using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class DocumentLog
    {
        public int IdDocumentLog { get; set; }
        public int? IdDocument { get; set; }
        public string PathDocument { get; set; }

        public virtual Document IdDocumentNavigation { get; set; }
    }
}
