using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class CatalogueDetailIns
    {
        public decimal IdCatalogueDetailsIns { get; set; }
        public int? IdInstitution { get; set; }
        public int? IdCatalogue { get; set; }

        public virtual Catalogue IdCatalogueNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
    }
}
