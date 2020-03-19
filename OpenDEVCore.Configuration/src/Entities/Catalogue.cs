using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Catalogue
    {
        public Catalogue()
        {
            CatalogueDetail = new HashSet<CatalogueDetail>();
            CatalogueDetailIns = new HashSet<CatalogueDetailIns>();
        }

        public int IdCatalogue { get; set; }
        public string Module { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsInstitution { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<CatalogueDetail> CatalogueDetail { get; set; }
        public virtual ICollection<CatalogueDetailIns> CatalogueDetailIns { get; set; }
    }
}
