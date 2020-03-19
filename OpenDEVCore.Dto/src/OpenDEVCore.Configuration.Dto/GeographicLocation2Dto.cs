using Core.General;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class GeographicLocation2Dto : CoreDto
    {
        public int IdGeographicLocation2 { get; set; }
        public int? IdGeographicLocation1 { get; set; }
        public string GeographicLocation2Code { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public List<GeographicLocation3Dto> GeographicLocation3 { get; set; }
    }
}
