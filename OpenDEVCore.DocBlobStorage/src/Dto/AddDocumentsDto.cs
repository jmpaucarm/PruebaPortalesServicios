using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class AddDocumentsDto
    {
        public List<DocumentDto> listDocumentos { get; set; }
        public bool save { get; set; }

    }
}
