using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDEVCore.Configuration.Dto
{
    public class EsbendPointExceptionDto
    {
        public int IdEsbendPointException { get; set; }
        public int? IdEsbendPoint { get; set; }
        public int? IdEsbexception { get; set; }
        public string EndPointErrorCode { get; set; }
        public string EndPointMessage { get; set; }
        public string Key { get; set; }


        public virtual EsbendPointDto IdEsbendPointNavigation { get; set; }
        public virtual EsbexceptionDto IdEsbexceptionNavigation { get; set; }
    }
}
