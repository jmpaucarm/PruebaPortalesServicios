using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Office
    {
        public int IdOffice { get; set; }
        public int IdInstitution { get; set; }
        public int? IdRegionInstitution { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int? IdGeographicLocation1 { get; set; }
        public int? IdGeographicLocation2 { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }
        public bool? IsActive { get; set; }
        public string IdOfficeDepend { get; set; }
        public int? IdOfficeCtb { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Institution IdInstitutionNavigation { get; set; }
    }
}
