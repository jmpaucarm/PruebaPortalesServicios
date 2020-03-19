using System;
using System.Collections.Generic;

namespace OpenDEVCore.DocBlobStorage.Dto
{
    public partial class FolderDto
    {

        public int IdFolder { get; set; }
        public string CodeTypeFolder { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int? IdBox { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsActive { get; set; }


        public virtual BoxDto IdBoxNavigation { get; set; }
        public virtual List<DocumentDto> Document { get; set; }
        public virtual List<FolderFieldDto> FolderField { get; set; }




      




    }
}
