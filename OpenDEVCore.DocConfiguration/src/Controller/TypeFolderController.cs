using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services;



namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TypeFolderController : ControllerBase
    {
        private readonly ITypeFolderService _typeFolderService;
        /// <summary>
        /// Constructor for the respective controller
        /// </summary>
        /// <param name="typeFolderService">Represents the service that manages the dto</param>
        public TypeFolderController(ITypeFolderService typeFolderService)
        {
            _typeFolderService = typeFolderService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<TypeFolderDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _typeFolderService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }
               
        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="TypeFolderDto"></param>
        /// <returns>TypeFolderDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TypeFolderDto TypeFolderDto)
        {
            var postedTypeDocuemt = await _typeFolderService.Add(TypeFolderDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the TypeFolderDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>TypeFolderDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeFolderService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if TypeFolderDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeFolderService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TypeFolderDto TypeFolderDto)
        {
            var typeDocuemnts = await _typeFolderService.Edit(TypeFolderDto);
            return Ok(typeDocuemnts);
        }
    }
}
