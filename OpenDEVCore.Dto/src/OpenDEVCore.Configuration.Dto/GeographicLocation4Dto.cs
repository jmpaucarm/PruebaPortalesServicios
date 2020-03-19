using Core.General;

namespace OpenDEVCore.Configuration.Dto
{
    public class GeographicLocation4Dto : CoreDto
    {
        public int IdGeographicLocation4 { get; set; }
        public int? IdGeographicLocation3 { get; set; }
        public string GeographicLocation4Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
