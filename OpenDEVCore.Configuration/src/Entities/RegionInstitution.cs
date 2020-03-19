using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class RegionInstitution
    {
        public int IdRegionInstitution { get; set; }
        public int? IdInstitution { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Descripcion { get; set; }
    }
}
