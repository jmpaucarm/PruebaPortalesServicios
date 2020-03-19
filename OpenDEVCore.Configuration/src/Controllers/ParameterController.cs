using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class ParameterController : BaseController
    {
        private readonly IParameterService _parameterService;

        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet("getparameterbycode")]
        public async Task<IActionResult> Get([FromQuery] string code)
            => Ok(await _parameterService.GetAsync(code));

        [HttpGet("findparameter")]
        public async Task<IActionResult> FindParameter([FromQuery] string code)
         => Ok(await _parameterService.FindParameterAsync(code));


        [HttpGet("getparameterbyid")]
        public async Task<IActionResult> GetById( [FromQuery] int id)
            => Ok(await _parameterService.GetByIdAsync(id));


        [HttpGet("getallparameters")]
        public async Task<IActionResult> GetAll()
         => Ok(await _parameterService.GetAllAsync());

        [HttpPost("addparameter")]
        public async Task<IActionResult> Add(AddParameterDto parameterDto) =>
           Ok(await _parameterService.AddAsync(parameterDto));

        [HttpPost("editparameter")]
        public async Task<IActionResult> Edit(EditParameterDto parameterDto) =>
            Ok(await _parameterService.EditAsync(parameterDto));
    }
}
