namespace OpenDEVCore.Security.Dto
{
    public class OptionDto
    {
        public int IdMenu { get; set; }
        public int IdOption { get; set; }
        public string Type { get; set; }
        public string View { get; set; }
        public string Url { get; set; }
        public string DashBoard { get; set; }
        public string Report { get; set; }
        public bool IsAdministrative { get; set; }
    }
}
