using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDEVCore.Configuration.Dto
{
    public class EsbendPointDto
    {
        public EsbendPointDto()
        {
            EsbendPointException = new HashSet<EsbendPointExceptionDto>();
        }

        public int IdEsbendPoint { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EsbendPointExceptionDto> EsbendPointException { get; set; }
    }
}
