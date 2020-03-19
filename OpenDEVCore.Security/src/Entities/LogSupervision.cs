using System;

namespace OpenDEVCore.Security.Entities
{
    public partial class LogSupervision
    {
        public int IdLogSupervision { get; set; }
        public int IdSupervision { get; set; }
        public int IdUser { get; set; }
        public string Transaction { get; set; }
        public string Action { get; set; }
        public DateTime? Date { get; set; }
        public int? IdOffice { get; set; }
        public string Observation { get; set; }
    }
}
