using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class GeographicLocation2
    {
        public GeographicLocation2()
        {
            GeographicLocation3 = new HashSet<GeographicLocation3>();
        }

        public int IdGeographicLocation2 { get; set; }
        public int? IdGeographicLocation1 { get; set; }
        public string GeographicLocation2Code { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }

        public virtual GeographicLocation1 IdGeographicLocation1Navigation { get; set; }
        public virtual ICollection<GeographicLocation3> GeographicLocation3 { get; set; }
    }
}
