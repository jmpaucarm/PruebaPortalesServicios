using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class DocumentLogDto
    {
        public int IdDocumentLog { get; set; }
        public int? IdDocument { get; set; }
        public string PathDocument { get; set; }

        public virtual DocumentDto IdDocumentNavigation { get; set; }
    }
}
