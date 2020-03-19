namespace OpenDEVCore.Security.Entities
{
    public partial class ProfileOption
    {
        public int IdProfileOption { get; set; }
        public int IdOption { get; set; }
        public int IdProfile { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsActive { get; set; }

        public virtual Option IdOptionNavigation { get; set; }
        public virtual Profile IdProfileNavigation { get; set; }

    }
}
