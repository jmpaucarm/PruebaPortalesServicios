namespace OpenDEVCore.Security.Entities
{
    public partial class InstitutionProfile
    {
        public int IdInstitutionProfile { get; set; }
        public int? IdProfile { get; set; }
        public int? IdInstitution { get; set; }

        public virtual Profile IdProfileNavigation { get; set; }
    }
}
