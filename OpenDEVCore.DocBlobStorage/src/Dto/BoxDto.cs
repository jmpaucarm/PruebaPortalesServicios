using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public class BoxDto
    {

        public int IdBox { get; set; }
        public string CodeTypeBox { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? IdLocation { get; set; }
        public short? NumberItems { get; set; }
        public bool? IsActive { get; set; }

      





        public virtual LocationDto IdLocationNavigation { get; set; }
        public virtual List<BoxFieldDto> BoxField { get; set; }
        public virtual List<FolderDto> Folder { get; set; }
    }
}
