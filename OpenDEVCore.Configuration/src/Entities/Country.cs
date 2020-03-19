using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Country
    {
        public Country()
        {
            GeographicLocation1 = new HashSet<GeographicLocation1>();
        }

        public int IdCountry { get; set; }
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<GeographicLocation1> GeographicLocation1 { get; set; }
    }
}
