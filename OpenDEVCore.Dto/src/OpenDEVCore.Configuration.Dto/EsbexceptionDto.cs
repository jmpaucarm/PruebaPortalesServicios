using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDEVCore.Configuration.Dto
{
    public class EsbexceptionDto
    {

        public EsbexceptionDto()
        {
            EsbendPointException = new HashSet<EsbendPointExceptionDto>();
        }

        public int IdEsbexception { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EsbendPointExceptionDto> EsbendPointException { get; set; }
    }
}
