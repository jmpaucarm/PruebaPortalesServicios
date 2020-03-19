using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FileController :ControllerBase
    {

        private readonly IDocumentService _documentService;

        public FileController(IDocumentService documentService)
        {
            _documentService = documentService;
        }



        [HttpGet("getdocumentbytype")]
        public async Task<IActionResult> GetDocumentByType([FromQuery] String obj)
        {

            DocumentByTypeDto document = JsonConvert.DeserializeObject<DocumentByTypeDto>(obj);




            var postedTypeDocuemt = await _documentService.GetDocumentByType(document.doctype, document.documentByCodesDt);


            var cd = new ContentDisposition
            {
                FileName = "xx",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            return File(postedTypeDocuemt, "application/pdf");

        }


        //[HttpPost("getdocumentbytype")]
        //public async Task<IActionResult> GetDocumentByType([FromBody] DocumentByTypeDto document)
        //{

        //    var postedTypeDocuemt = await _documentService.GetDocumentByType(document.doctype, document.documentByCodesDt);

        //    var cd = new ContentDisposition
        //    {
        //        FileName = "xx",
        //        Inline = true
        //    };
        //    Response.Headers.Add("Content-Disposition", cd.ToString());
        //    Response.Headers.Add("X-Content-Type-Options", "nosniff");

        //    return File(postedTypeDocuemt, "application/pdf");

        //}



        //[HttpGet("test")]
        //public async Task<IActionResult> test()

        //{

        //    var fileStream = new MemoryStream(await System.IO.File.ReadAllBytesAsync(@"C:\Users\Jhonathan.Paucar\Desktop\test.pdf"));

        //    if (fileStream == null)
        //        return NotFound();



        //    var cd = new ContentDisposition
        //    {
        //        FileName = "test.pdf",
        //        Inline = true
        //    };
        //    Response.Headers.Add("Content-Disposition", cd.ToString());
        //    Response.Headers.Add("X-Content-Type-Options", "nosniff");

        //    return File(fileStream, "application/pdf");

        //}
    }
}
