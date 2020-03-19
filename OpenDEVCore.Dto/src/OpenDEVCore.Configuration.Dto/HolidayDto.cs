using System;

namespace OpenDEVCore.Configuration.Dto
{
    public class HolidayDto
    {
        public int IdHoliday { get; set; }
        public int? Year { get; set; }
        public int IdGeographicLocation2 { get; set; }
        public long DateHoliday { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
       
    }
}
