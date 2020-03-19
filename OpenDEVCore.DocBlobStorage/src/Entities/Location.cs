using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Entities
{
    public partial class Location
    {
        public Location()
        {
            Box = new HashSet<Box>();
        }

        public int IdLocation { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Hijo { get; set; }
        public int? Padre { get; set; }
        public bool? IsLastNode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<Box> Box { get; set; }
    }
}
