using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class GeographicLocation4
    {
        public int IdGeographicLocation4 { get; set; }
        public int? IdGeographicLocation3 { get; set; }
        public string GeographicLocation4Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual GeographicLocation3 IdGeographicLocation3Navigation { get; set; }
    }
}
