using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Zone
    {
        public int IdZone { get; set; }
        public string GeographicLocationCode { get; set; }
        public string ZoneCode { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
    }
}
