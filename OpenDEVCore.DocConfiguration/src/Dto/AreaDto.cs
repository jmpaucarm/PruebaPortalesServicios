

namespace OpenDevCore.DocConfiguration.Dto
{
    public class AreaDto
    {
        public int IdArea { get; set; }
        public int? IdTypeDocument { get; set; }
        public string Code { get; set; }
        public short? X { get; set; }
        public short? Y { get; set; }
        public short? Tall { get; set; }
        public short? Wide { get; set; }
        public int? IdNewTypeDocument { get; set; }
        public bool? IsActive { get; set; }

        public virtual TypeDocumentDto IdTypeDocumentNavigation { get; set; }
    }
}
