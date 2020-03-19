using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class EsbendPointException
    {
        public int IdEsbendPointException { get; set; }
        public int? IdEsbendPoint { get; set; }
        public int? IdEsbexception { get; set; }
        public string EndPointErrorCode { get; set; }
        public string EndPointMessage { get; set; }

        public virtual EsbendPoint IdEsbendPointNavigation { get; set; }
        public virtual Esbexception IdEsbexceptionNavigation { get; set; }
    }
}
