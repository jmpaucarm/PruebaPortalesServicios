using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class DocumentByTypeDto
    {
        public string doctype { get; set; }
        public DocumentByCodesDto documentByCodesDt { get; set; }


    }
}
