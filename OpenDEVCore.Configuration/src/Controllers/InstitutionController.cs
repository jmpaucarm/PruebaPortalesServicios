using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class InstitutionController : BaseController
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpGet("findinstitutionbyruc")]
        public async Task<IActionResult> FindByRuc([FromQuery] string ruc)
          => Ok(await _institutionService.FindByRucAsync(ruc));


        [HttpGet("getinstitutionbyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
            => Ok(await _institutionService.GetByIdAsync(id));

        [HttpGet("getinstitutionbycode")]
        public async Task<IActionResult> GetByCode([FromQuery] string code)
            => Ok(await _institutionService.GetByCodeAsync(code));

        [HttpGet("getallinstitutions")]
        public async Task<IActionResult> GetAllInstitutions([FromQuery] bool onlyActive, [FromQuery] bool onlyInstitution) 
            => Ok(await _institutionService.GetAllAsync(onlyActive,onlyInstitution));

        [HttpPost("addinstitution")]
        public async Task<IActionResult> Add(AddInstitutionDto institutionDto) =>
         Ok(await _institutionService.AddAsync(institutionDto));

        [HttpPost("editinstitution")]
        public async Task<IActionResult> Edit(EditInstitutionDto institutionDto) =>
            Ok(await _institutionService.EditAsync(institutionDto));

    }
}
