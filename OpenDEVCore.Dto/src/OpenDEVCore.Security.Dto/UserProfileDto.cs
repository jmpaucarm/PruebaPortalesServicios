namespace OpenDEVCore.Security.Dto
{
    public class UserProfileDto
    {
        public int IdUserProfile { get; set; }
        public int? IdProfile { get; set; }
        public int? IdUser { get; set; }
        public int IdOffice { get; set; }
        public long DateFrom { get; set; }
        public long? DateUntil { get; set; }
        public bool IsActive { get; set; }
        public long CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public long UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
    }
}
