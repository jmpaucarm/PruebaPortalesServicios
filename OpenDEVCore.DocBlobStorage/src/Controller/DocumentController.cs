using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDEVCore.DocBlobStorage.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] AddDocumentsDto parametros)
        {
            var listaDocumentos = parametros.listDocumentos;
            var save = parametros.save;

            var postedTypeDocuemt = await _documentService.Add(listaDocumentos, save);
            return Ok(postedTypeDocuemt);
        }

        [HttpGet("getdocumentbyid")]
        public async Task<IActionResult> GetDocumentById([FromQuery] int idDocument)
        {
            var postedTypeDocuemt = await _documentService.GetDocumentById(idDocument);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// THIS METHOD RETURN A LIST OF DOCUMENTS THAT MATCHES WITH A GIVEN KEY WORD  
        /// /// </summary>
        /// <param name="codes"></param>
        /// <param name="institution"></param>
        /// <returns></returns>
        [HttpPost   ("getdocumetnodata")]
        public async Task<IActionResult> GetByCodes([FromBody]DocumentByCodesDto documentByCodesDto)
        {
            var postedTypeDocuemt = await _documentService.GetByCodes(documentByCodesDto);
            return Ok(postedTypeDocuemt);
    
        }

        [HttpGet("finddocument")]
        public async Task<IActionResult> FindDocument([FromQuery] string code, [FromQuery] string institution)
        {
            var postedTypeDocuemt = await _documentService.FindByCode(code, institution);
            return Ok(postedTypeDocuemt);
        }





      







    }
}
