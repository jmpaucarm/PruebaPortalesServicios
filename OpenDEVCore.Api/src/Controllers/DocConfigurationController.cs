using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DocConfigurationController : BaseController
    {
        private readonly IDocConfiguration _docConfigurationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Controlador de Configuration
        /// </summary>
        /// <param name="busPublisher"></param>
        /// <param name="docConfigurationService"></param>
        /// <param name="httpContextAccessor"></param>
        public DocConfigurationController(IBusPublisher busPublisher,
            IDocConfiguration docConfigurationService, IHttpContextAccessor httpContextAccessor) : base(busPublisher)
        {
            _docConfigurationService = docConfigurationService;
            _httpContextAccessor = httpContextAccessor;
            _docConfigurationService.jsonSession = SessionContext.GetJsonSession();
        }
        #region Field

        [AllowAnonymous]
        [HttpGet("getallfield")]
        public async Task<IActionResult> GetAllField([FromQuery]string institution, [FromQuery]bool active)
           => Single(await _docConfigurationService.GetAllField(institution, active));

        [AllowAnonymous]
        [HttpGet("findbycodesfield")]
        public async Task<IActionResult> FindByCodesField([FromQuery]string institution, [FromBody] List<string> codes)
            => Single(await _docConfigurationService.FindByCodesField(institution, codes));

        [AllowAnonymous]
        [HttpPost("addfield")]
        public async Task<IActionResult> AddField([FromBody]FieldDto FieldDto)
            => Single(await _docConfigurationService.AddField(FieldDto));

        [AllowAnonymous]
        [HttpGet("getbycodefield")]
        public async Task<IActionResult> GetByCodeField([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeField(code, institution));

        [AllowAnonymous]
        [HttpGet("findfield")]
        public async Task<IActionResult> FindField([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindField(code, institution));

        [AllowAnonymous]
        [HttpPut("editfield")]
        public async Task<IActionResult> EditField([FromBody]FieldDto fieldDto)
            => Single(await _docConfigurationService.EditField(fieldDto));
        #endregion

        #region TypeBox

        [AllowAnonymous]
        [HttpGet("getalltypebox")]
        public async Task<IActionResult> GetAllTypeBox([FromQuery]string institution, [FromQuery]bool active)
                => Single(await _docConfigurationService.GetAllTypeBox(institution, active));

        [AllowAnonymous]
        [HttpPost("addtypebox")]
        public async Task<IActionResult> AddTypeBox([FromBody]TypeBoxDto typeBoxDto)
      => Single(await _docConfigurationService.AddTypeBox(typeBoxDto));

        [AllowAnonymous]
        [HttpGet("getbycodetypebox")]
        public async Task<IActionResult> GetByCodeTypeBox([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeTypeBox(code, institution));

        [AllowAnonymous]
        [HttpGet("findtypebox")]
        public async Task<IActionResult> FindTypeBox([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindTypeBox(code, institution));

        [AllowAnonymous]
        [HttpPut("edittypebox")]
        public async Task<IActionResult> EditTypeBox([FromBody]TypeBoxDto typeBoxDto)
            => Single(await _docConfigurationService.EditTypeBox(typeBoxDto));

        #endregion

        #region TypeDocument
        [AllowAnonymous]
        [HttpGet("getalltypedocument")]
        public async Task<IActionResult> GetAllTypeDocument([FromQuery]string institution, [FromQuery]bool active)
        => Single(await _docConfigurationService.GetAllTypeDocument(institution, active));

        [AllowAnonymous]
        [HttpGet("findbycodestypedocument")]
        public async Task<IActionResult> FindByCodesTypeDocument([FromQuery]string institution, [FromBody] List<string> codes)
        => Single(await _docConfigurationService.FindByCodesTypeDocument(institution, codes));
        
        [AllowAnonymous]
        [HttpPost("addtypedocument")]
        public async Task<IActionResult> AddTypeDocument([FromBody]TypeDocumentDto typeDocumentDto)
        => Single(await _docConfigurationService.AddTypeDocument(typeDocumentDto));

        [AllowAnonymous]
        [HttpGet("getbycodetypedocument")]
        public async Task<IActionResult> GetByCodeTypeDocument([FromQuery]string code, [FromQuery] string institution)
        => Single(await _docConfigurationService.GetByCodeTypeDocument(code, institution));

        [AllowAnonymous]
        [HttpGet("findtypedocument")]
        public async Task<IActionResult> FindTypeDocument([FromQuery]string code, [FromQuery] string institution)
        => Single(await _docConfigurationService.FindTypeDocument(code, institution));

        [AllowAnonymous]
        [HttpPut("getconfigurations")]
        public async Task<IActionResult> GetConfigurations([FromQuery]string institution, [FromQuery] string[] codes)
        => Single(await _docConfigurationService.GetConfigurations(institution,codes));


        [AllowAnonymous]
        [HttpPut("edittypedocument")]
        public async Task<IActionResult> EditTypeDocument([FromBody]TypeDocumentDto typeDocumentDto)
        => Single(await _docConfigurationService.Edit(typeDocumentDto));

        [AllowAnonymous]
        [HttpGet("getallformtypedocument")]
        public async Task<IActionResult> GetAllFormTypeDocument([FromQuery]string institution, [FromQuery]bool isForm)
        => Single(await _docConfigurationService.GetAllForm(institution,isForm));

        #endregion

        #region TypeFolder
        [AllowAnonymous]
        [HttpGet("getalltypefolder")]
        public async Task<IActionResult> GetAllTypeFolder([FromQuery]string institution, [FromQuery]bool active)
             => Single(await _docConfigurationService.GetAllTypeFolder(institution, active));

        [AllowAnonymous]
        [HttpPost("addtypefolder")]
        public async Task<IActionResult> AddTypeFolder([FromBody]TypeFolderDto typeFolderDto)
            => Single(await _docConfigurationService.AddTypeFolder(typeFolderDto));

        [AllowAnonymous]
        [HttpGet("getbycodetypefolder")]
        public async Task<IActionResult> GetByCodeTypeFolder([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeTypeFolder(code, institution));

        [AllowAnonymous]
        [HttpGet("findtypefolder")]
        public async Task<IActionResult> FindTypeFolder([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindTypeFolder(code, institution));

        [AllowAnonymous]
        [HttpPut("edittypefolder")]
        public async Task<IActionResult> EditTypeFolder([FromBody]TypeFolderDto typeFolderDto)
            => Single(await _docConfigurationService.EditTypeFolder(typeFolderDto));

        #endregion

        #region TypeImage
        [AllowAnonymous]
        [HttpGet("getalltypeimage")]
        public async Task<IActionResult> GetAllTypeImage([FromQuery]string institution, [FromQuery]bool active)
           => Single(await _docConfigurationService.GetAllTypeImage(institution, active));

        [AllowAnonymous]
        [HttpPost("addtypeimage")]
        public async Task<IActionResult> AddTypeImage([FromBody]TypeImageDto typeImageDto)
            => Single(await _docConfigurationService.AddTypeImage(typeImageDto));

        [AllowAnonymous]
        [HttpGet("getbycodetypeimage")]
        public async Task<IActionResult> GetByCodeTypeImage([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeTypeImage(code, institution));

        [AllowAnonymous]
        [HttpGet("findtypeimage")]
        public async Task<IActionResult> FindTypeImage([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindTypeImage(code, institution));

        [AllowAnonymous]
        [HttpPut("edittypeimage")]
        public async Task<IActionResult> EditTypeImage([FromBody]TypeImageDto typeImageDto)
            => Single(await _docConfigurationService.EditTypeImage(typeImageDto));


        #endregion

        #region FormVersion
        [AllowAnonymous]
        [HttpGet("getallformversion")]
        public async Task<IActionResult> GetAllFormVersion([FromQuery]string institution, [FromQuery]bool active)
           => Single(await _docConfigurationService.GetAllFormVersion(institution, active));

        [AllowAnonymous]
        [HttpPost("addformversion")]
        public async Task<IActionResult> AddFormVersion([FromBody]FormVersionDto formVersionDto)
            => Single(await _docConfigurationService.AddFormVersion(formVersionDto));

        [AllowAnonymous]
        [HttpGet("getbycodeformversion")]
        public async Task<IActionResult> GetByCodeFormVersion([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeFormVersion(code, institution));

        [AllowAnonymous]
        [HttpGet("findformversion")]
        public async Task<IActionResult> FindFormVersion([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindFormVersion(code, institution));

        [AllowAnonymous]
        [HttpPut("editformversion")]
        public async Task<IActionResult> EditFormVersion([FromBody]FormVersionDto formVersionDto)
            => Single(await _docConfigurationService.EditFormVersion(formVersionDto));
        #endregion

        #region Watermark
        [AllowAnonymous]
        [HttpGet("getallwatermark")]
        public async Task<IActionResult> GetAllWaterMark([FromQuery]string institution, [FromQuery]bool active)
           => Single(await _docConfigurationService.GetAllWaterMark(institution, active));

        [AllowAnonymous]
        [HttpPost("addwatermark")]
        public async Task<IActionResult> AddWaterMark([FromBody]WaterMarkDto waterMarkDto)
            => Single(await _docConfigurationService.AddWaterMark(waterMarkDto));

        [AllowAnonymous]
        [HttpGet("getbycodewatermark")]
        public async Task<IActionResult> GetByCodeWaterMark([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.GetByCodeWaterMark(code, institution));

        [AllowAnonymous]
        [HttpGet("findwatermark")]
        public async Task<IActionResult> FindWaterMark([FromQuery]string code, [FromQuery] string institution)
            => Single(await _docConfigurationService.FindWaterMark(code, institution));

        [AllowAnonymous]
        [HttpPut("editwatermark")]
        public async Task<IActionResult> EditWaterMark([FromBody]WaterMarkDto waterMarkDto)
            => Single(await _docConfigurationService.EditWaterMark(waterMarkDto));
        #endregion

    }
}