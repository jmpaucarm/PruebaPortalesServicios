
using System.Collections.Generic;


namespace OpenDEVCore.Api.Dtos
{
    public class AddDocumentsDto
    {
        public List<DocumentDto> listDocumentos { get; set; }
        public bool save { get; set; }

    }
}
