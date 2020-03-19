using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class CatalogueDetail
    {
        public int IdCatalogueDetail { get; set; }
        public int IdCatalogue { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Catalogue IdCatalogueNavigation { get; set; }
    }
}
