using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Institution
    {
        public Institution()
        {
            CatalogueDetailIns = new HashSet<CatalogueDetailIns>();
            InstitutionSystem = new HashSet<InstitutionSystem>();
            Office = new HashSet<Office>();
        }

        public int IdInstitution { get; set; }
        public string Ruc { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RepresentativeTypeDni { get; set; }
        public string RepresentativeDni { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeEmail { get; set; }
        public string RepresentativePhone { get; set; }
        public string Domain { get; set; }
        public string Design { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsActive { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<CatalogueDetailIns> CatalogueDetailIns { get; set; }
        public virtual ICollection<InstitutionSystem> InstitutionSystem { get; set; }
        public virtual ICollection<Office> Office { get; set; }
    }
}
