using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class DocumentByCodesDto
    {
        public List<KeyValuePair<string, string>> Codes { get; set; }
        public string Institution { get; set; }
    }
}
