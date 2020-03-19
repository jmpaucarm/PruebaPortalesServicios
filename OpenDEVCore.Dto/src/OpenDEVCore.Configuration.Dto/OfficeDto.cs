using System;

namespace OpenDEVCore.Configuration.Dto
{
    public class OfficeDto 
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
    }
}
