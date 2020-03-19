using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class BoxField
    {
        public int IdBoxField { get; set; }
        public int? IdBox { get; set; }
        public string CodeField { get; set; }
        public string Institution { get; set; }
        public string Value { get; set; }

        public virtual Box IdBoxNavigation { get; set; }
    }
}
