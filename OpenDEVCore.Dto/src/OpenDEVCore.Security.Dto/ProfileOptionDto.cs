
namespace OpenDEVCore.Security.Dto
{
    public class ProfileOptionDto
    {
        public int IdProfileOption { get; set; }
        public int IdOption { get; set; }
        public int IdProfile { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsActive { get; set; }
        //public OptionDto IdOptionNavigation { get; set; }
    }
}