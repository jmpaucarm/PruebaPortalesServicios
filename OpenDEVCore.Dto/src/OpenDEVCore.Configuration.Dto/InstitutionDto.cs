using Core.General;
using System;
using System.Collections.Generic;


namespace OpenDEVCore.Configuration.Dto 
{
    public class InstitutionDto : CoreDto
    {
        public int IdInstitution { get; set; }
        public string Ruc { get; set; }
        public string Name { get; set; }
        public string RepresentativeTypeDni { get; set; }
        public string RepresentativeDni { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeEmail { get; set; }
        public string RepresentativePhone { get; set; }
        public string Domain { get; set; }
        public string Design { get; set; }
        public bool? IsActive { get; set; }
        public string CompanyCode { get; set; }

        public List<OfficeDto> Office { get; set; }
    }
}
