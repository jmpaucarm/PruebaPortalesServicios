
using System;


namespace OpenDEVCore.Api.Dtos
{
    public partial class DocumentDto
    {

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

        public string CodeDocument { get; set; }

    }
}
