using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class DocumentNoDataDto
    {
        public int IdDocument { get; set; }
        public string CodeTypeDocument { get; set; }
        public string CodeDocument { get; set; }
        public string Institution { get; set; }
        public string Type { get; set; }

    }
}
