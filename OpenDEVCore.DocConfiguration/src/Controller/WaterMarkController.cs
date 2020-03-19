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
    public class WaterMarkController : ControllerBase
    {
        private readonly IWaterMarkService _waterMarkService;

        public WaterMarkController(IWaterMarkService waterMarkService)
        {
            _waterMarkService = waterMarkService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<WaterMarkDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _waterMarkService.GetAll(institution, active);
            WaterMarkDto result = new WaterMarkDto
            {
                IdWaterMark = -1,
                Code = "XXX-XXX",
                Description = "NUEVO"
            };
            typeDocuemnts.Add(result);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="WaterMarkDto"></param>
        /// <returns>WaterMarkDto</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Add(WaterMarkDto WaterMarkDto)
        {
            var postedTypeDocuemt = await _waterMarkService.Add(WaterMarkDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the WaterMarkDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>WaterMarkDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _waterMarkService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Return true if WaterMarkDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _waterMarkService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(WaterMarkDto WaterMarkDto)
        {
            var typeDocuemnts = await _waterMarkService.Edit(WaterMarkDto);
            return Ok(typeDocuemnts);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var typeDocuemnts = await _waterMarkService.GetById(id);
            return Ok(typeDocuemnts);
        }

    }
}
