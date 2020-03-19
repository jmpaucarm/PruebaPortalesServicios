using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class GeographicLocation1
    {
        public GeographicLocation1()
        {
            GeographicLocation2 = new HashSet<GeographicLocation2>();
        }

        public int IdGeographicLocation1 { get; set; }
        public int? IdCountry { get; set; }
        public string GeographicLocation1Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual ICollection<GeographicLocation2> GeographicLocation2 { get; set; }
    }
}
