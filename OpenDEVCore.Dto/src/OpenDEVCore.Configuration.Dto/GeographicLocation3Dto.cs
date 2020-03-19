using Core.General;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class GeographicLocation3Dto : CoreDto
    {
        public int IdGeographicLocation3 { get; set; }
        public int? IdGeographicLocation2 { get; set; }
        public string GeographicLocation3Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public List<GeographicLocation4Dto> GeographicLocation4 { get; set; }
    }
}
