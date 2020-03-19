
using System.Threading.Tasks;
using Core.Mvc;
using Core.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Api.Dtos;
using OpenDEVCore.Api.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenDEVCore.Api.Controllers
{
    public class BlobStorageController : BaseController
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Controlador de Configuration
        /// </summary>
        /// <param name="busPublisher"></param>
        /// <param name="blobStorageService"></param>
        /// <param name="httpContextAccessor"></param>
        public BlobStorageController(IBusPublisher busPublisher,
            IBlobStorageService blobStorageService, IHttpContextAccessor httpContextAccessor) : base(busPublisher)
        {
            _blobStorageService = blobStorageService;
            _httpContextAccessor = httpContextAccessor;
            _blobStorageService.jsonSession = SessionContext.GetJsonSession();
        }

        #region Document

        [AllowAnonymous]
        [HttpPost("savedocuments")]
        public async Task<IActionResult> SaveDocuments([FromBody] AddDocumentsDto parametros)
            => Single(await _blobStorageService.SaveDocuments(parametros));

        [AllowAnonymous]
        [HttpGet("getdocumentbyid")]
        public async Task<IActionResult> GetDocumentById([FromQuery] int idDocument)
          => Single(await _blobStorageService.GetDocumentById(idDocument));


        [AllowAnonymous]
        [HttpGet("getdocumetnodata")]
        public async Task<IActionResult> GetDocumetNoData([FromQuery] string[] codes, [FromQuery] string institution)
          => Single(await _blobStorageService.GetDocumetNoData(codes,institution));


        #endregion




    }
}
