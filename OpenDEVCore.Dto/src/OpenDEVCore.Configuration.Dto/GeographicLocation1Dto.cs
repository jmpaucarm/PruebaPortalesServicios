using Core.General;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Dto
{
    public class GeographicLocation1Dto : CoreDto
    {
        public int IdGeographicLocation1 { get; set; }
        public int? IdCountry { get; set; }
        public string GeographicLocation1Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public List<GeographicLocation2Dto> GeographicLocation2 { get; set; }
    }
}
