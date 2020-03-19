using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class BoxFieldDto
    {
        public int IdBoxField { get; set; }
        public int? IdBox { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual BoxDto IdBoxNavigation { get; set; }
    }
}
