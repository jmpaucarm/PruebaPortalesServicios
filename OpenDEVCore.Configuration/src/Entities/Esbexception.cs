using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Esbexception
    {
        public Esbexception()
        {
            EsbendPointException = new HashSet<EsbendPointException>();
        }

        public int IdEsbexception { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EsbendPointException> EsbendPointException { get; set; }
    }
}
