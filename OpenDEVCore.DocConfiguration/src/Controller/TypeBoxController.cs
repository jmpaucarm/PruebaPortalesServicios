using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Repositories;



namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TypeBoxController : ControllerBase
    {
        private readonly ITypeBoxService _typeBoxService;
        /// <summary>
        /// Constructor for the respective controller
        /// </summary>
        /// <param name="typeBoxService">Represents the service that manages the dto</param>
        public TypeBoxController(ITypeBoxService typeBoxService)
        {
            _typeBoxService = typeBoxService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<TypeBoxDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _typeBoxService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }
          /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="TypeBoxDto"></param>
        /// <returns>TypeBoxDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TypeBoxDto TypeBoxDto)

        {
            var postedTypeDocuemt = await _typeBoxService.Add(TypeBoxDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the TypeBoxDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>TypeBoxDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeBoxService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if TypeBoxDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeBoxService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TypeBoxDto TypeBoxDto)
        {
            var typeDocuemnts = await _typeBoxService.Edit(TypeBoxDto);
            return Ok(typeDocuemnts);
        }

    }
}
