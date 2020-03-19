using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class Box
    {
        public Box()
        {
            BoxField = new HashSet<BoxField>();
            Folder = new HashSet<Folder>();
        }

        public int IdBox { get; set; }
        public string CodeTypeBox { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? IdLocation { get; set; }
        public short? NumberItems { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        public virtual Location IdLocationNavigation { get; set; }
        public virtual ICollection<BoxField> BoxField { get; set; }
        public virtual ICollection<Folder> Folder { get; set; }
    }
}

    

