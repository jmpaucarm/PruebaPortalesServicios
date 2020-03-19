using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class EsbendPoint
    {
        public EsbendPoint()
        {
            EsbendPointException = new HashSet<EsbendPointException>();
        }

        public int IdEsbendPoint { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EsbendPointException> EsbendPointException { get; set; }
    }
}
