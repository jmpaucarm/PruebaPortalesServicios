using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class GeographicLocation3
    {
        public GeographicLocation3()
        {
            GeographicLocation4 = new HashSet<GeographicLocation4>();
        }

        public int IdGeographicLocation3 { get; set; }
        public int? IdGeographicLocation2 { get; set; }
        public string GeographicLocation3Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual GeographicLocation2 IdGeographicLocation2Navigation { get; set; }
        public virtual ICollection<GeographicLocation4> GeographicLocation4 { get; set; }
    }
}
