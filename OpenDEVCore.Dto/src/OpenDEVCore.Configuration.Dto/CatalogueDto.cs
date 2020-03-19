
using Core.General;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class CatalogueDto : CoreDto
    {
        public int IdCatalogue { get; set; }
        public string Module { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsInstitution { get; set; }
        
        public List<CatalogueDetailDto> CatalogueDetail { get; set; }
    }

}
