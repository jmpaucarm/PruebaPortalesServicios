namespace OpenDEVCore.Configuration.Dto
{
    public class CatalogueDetailDto
    {

        public int IdCatalogueDetail { get; set; }
        public int IdCatalogue { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
    }
}
