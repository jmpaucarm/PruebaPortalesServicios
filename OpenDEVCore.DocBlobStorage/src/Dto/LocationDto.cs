using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class LocationDto
    {
        public int IdLocation { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Hijo { get; set; }
        public int? Padre { get; set; }
        public bool? IsLastNode { get; set; }
        public bool? IsActive { get; set; }


        public virtual List<BoxDto> Box { get; set; }
    }
}
