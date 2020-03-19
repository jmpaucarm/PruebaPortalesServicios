using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services;


namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _typeFieldService;
        /// <summary>
        /// Constructor for the respective controller
        /// </summary>
        /// <param name="typeFieldService">Represents the service that manages the dto</param>
        public FieldController(IFieldService typeFieldService)
        {
            _typeFieldService = typeFieldService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<FieldDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _typeFieldService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }




        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="FieldDto"></param>
        /// <returns>FieldDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(FieldDto FieldDto)
        {
            var postedTypeDocuemt = await _typeFieldService.Add(FieldDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the FieldDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>FieldDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeFieldService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if FieldDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeFieldService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(FieldDto FieldDto)
        {
            var typeDocuemnts = await _typeFieldService.Edit(FieldDto);
            return Ok(typeDocuemnts);
        }

    }
}
