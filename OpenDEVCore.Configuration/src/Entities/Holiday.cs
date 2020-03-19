using System;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Holiday
    {
        public int IdHoliday { get; set; }
        public int? Year { get; set; }
        public int IdGeographicLocation2 { get; set; }
        public DateTime DateHoliday { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
    }
}
