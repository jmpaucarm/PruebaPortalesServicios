using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly IBoxService _boxService;

        public BoxController(IBoxService boxService)
        {
            _boxService = boxService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]BoxDto entBox)
        {
            var result = await _boxService.Add(entBox);
            return Ok(result);
        }


        [HttpGet("getbycode")]
        public async Task<IActionResult> Getbycode([FromQuery]string code,string institution)
        {
            var result = await _boxService.GetByCode(code, institution);
            return Ok(result);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery]string institution,bool active)
        {

            var result = await _boxService.GetAll(institution,active);
            return Ok(result);
        }

        [HttpPost("updateBox")]
        public async Task<IActionResult> UpdateFolder(BoxDto entBox)
        {

            var result = await _boxService.Edit(entBox);
            return Ok(result);
        }




    }
}
