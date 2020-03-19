 using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class CatalogueController : BaseController
    {
        private readonly ICatalogService _catalogService;

        public CatalogueController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("getcataloguebycode")]
        public async Task<IActionResult> GetByCode([FromQuery] string query, [FromQuery] int idInstitution)
            => Ok(await _catalogService.GetByCodeAsync(query,idInstitution));

        [HttpGet("getcataloguebyid")]
        public async Task<IActionResult> GetById([FromQuery] int id , [FromQuery] int idInstitution)
            => Ok(await _catalogService.GetByIdAsync(id, idInstitution));


        [HttpGet("getcatalogsbycodes")]
        public async Task<IActionResult> GetByCodes([FromQuery] string query, [FromQuery] int idInstitution)
      => Ok(await _catalogService.GetByCodesAsync(query, idInstitution));



        [HttpGet("getallcatalogs")]
        public async Task<IActionResult> GetAll()
        => Ok(await _catalogService.GetAllAsync());
        
        [HttpPost("addcatalogue")]
        public async Task<IActionResult> Add(CatalogueDto ctlgoDto) =>
            Ok(await _catalogService.AddAsync(ctlgoDto));

        [HttpPost("editcatalogue")]
        public async Task<IActionResult> Edit(CatalogueDto ctlgoDto) =>
            Ok(await _catalogService.EditAsync(ctlgoDto));

        [HttpGet("findcataloguebycode")]
        public async Task<IActionResult> FindByCode([FromQuery] string code, [FromQuery] int idInstitution)
            => Ok(await _catalogService.FindByCodeAsync(code, idInstitution));

    }
}
