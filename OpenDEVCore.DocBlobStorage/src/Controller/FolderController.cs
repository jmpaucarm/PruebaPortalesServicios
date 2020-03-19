using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Services;


namespace OpenDEVCore.DocBlobStorage.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderServices _iFolderServices;

        public FolderController(IFolderServices iFolderServices)
        {
            _iFolderServices = iFolderServices;
        }
                     

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]FolderDto entFolder)
        {
            var result =await _iFolderServices.Add(entFolder);
            return Ok(result);      
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> Getbyid([FromQuery]int id)
        {
            var result = await _iFolderServices.GetById(id);
            return Ok(result);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery]string  institution)
        {

            var result = await _iFolderServices.GetAll(institution);
            return Ok(result);
        }

        [HttpPost("updateFolder")]
        public async Task<IActionResult> UpdateFolder(FolderDto entFolder)
        {

            var result = await _iFolderServices.UpdateFolder(entFolder);
            return Ok(result);
        }





    }
}
