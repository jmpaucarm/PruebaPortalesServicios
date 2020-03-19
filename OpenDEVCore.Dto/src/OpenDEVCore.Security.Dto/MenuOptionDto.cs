using System;

namespace OpenDEVCore.Security.Dto
{
    public class MenuOptionDto
    {
        public int IdMenu { get; set; }
        public int? IdMenuOrigin { get; set; }
        public DateTime? DateSince { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public string Level { get; set; }
        public string Module { get; set; }
        public string View { get; set; }
        public string Url { get; set; }
        public string Channel { get; set; }
        public string Type { get; set; }
        public string DashBoard { get; set; }
        public string Report { get; set; }
        public bool IsAdministrative { get; set; }
        public string RouteLink { get; set; }
    }
}
