using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TypeImageController : ControllerBase
    {
        private readonly ITypeImageService _typeImageService;
        /// <summary>
        /// Constructor for the respective controller
        /// </summary>
        /// <param name="typeImageService">Represents the service that manages the dto</param>
        public TypeImageController(ITypeImageService typeImageService)
        {
            _typeImageService = typeImageService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<TypeImageDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _typeImageService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }
  
        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="TypeImageDto"></param>
        /// <returns>TypeImageDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TypeImageDto TypeImageDto)
        {
            var postedTypeDocuemt = await _typeImageService.Add(TypeImageDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the TypeImageDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>TypeImageDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeImageService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if TypeImageDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeImageService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TypeImageDto TypeImageDto)
        {
            var typeDocuemnts = await _typeImageService.Edit(TypeImageDto);
            return Ok(typeDocuemnts);
        }

    }
}
