using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FormVersionController : ControllerBase
    {
        private readonly IFormVersionService _formVersionService;

        public FormVersionController(IFormVersionService formVersionService )
        {
            _formVersionService = formVersionService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<FormVersionDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _formVersionService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="FormVersionDto"></param>
        /// <returns>FormVersionDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(FormVersionDto FormVersionDto)
        {
            var postedTypeDocuemt = await _formVersionService.Add(FormVersionDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the FormVersionDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>FormVersionDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _formVersionService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if FormVersionDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _formVersionService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(FormVersionDto FormVersionDto)
        {
            var typeDocuemnts = await _formVersionService.Edit(FormVersionDto);
            return Ok(typeDocuemnts);
        }
    }
}
