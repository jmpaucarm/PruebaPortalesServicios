using Core.Mvc;
using Core.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Api.Dtos;
using OpenDEVCore.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationService _iNotificationService;

        /// <summary>
        /// Constructor - Controlador de Configuration
        /// </summary>
        /// <param name="busPublisher"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="INotification"></param>
        public NotificationController(IBusPublisher busPublisher,
                                      IHttpContextAccessor httpContextAccessor,
                                      INotificationService INotificationService
                                     ) 
        : base(busPublisher)

        {
            _httpContextAccessor = httpContextAccessor;
            _iNotificationService = INotificationService;
            _iNotificationService.jsonSession = SessionContext.GetJsonSession();
        }

        #region Provider
        [AllowAnonymous]
        [HttpGet("getproviderbycode")]
        public async Task<IActionResult> GetByCodeProvider([FromQuery] string code, [FromQuery] string chanel, [FromQuery] string institution)
        => Ok(await _iNotificationService.GetByCodeAsyncProvider(code, chanel, institution));

        [AllowAnonymous]
        [HttpGet("findprovider")]
        public async Task<IActionResult> FindProviderProvider([FromQuery] string code, [FromQuery] string chanel, [FromQuery] string institution)
         => Ok(await _iNotificationService.FindAsyncProvider(code, chanel, institution));

        [AllowAnonymous]
        [HttpGet("getproviderbyid")]
        public async Task<IActionResult> GetByIdProvider([FromQuery] int id)
            => Ok(await _iNotificationService.GetByIdAsyncProvider(id));

        [AllowAnonymous]
        [HttpGet("getallproviders")]
        public async Task<IActionResult> GetAllProvider()
         => Ok(await _iNotificationService.GetAllAsyncProvider());

        [AllowAnonymous]
        [HttpPost("addprovider")]
        public async Task<IActionResult> AddProvider([FromBody]ProviderDto providerDto) =>
           Ok(await _iNotificationService.AddAsyncProvider(providerDto));

        [AllowAnonymous]
        [HttpPost("editprovider")]
        public async Task<IActionResult> EditProvider([FromBody]ProviderDto providerDto) =>
            Ok(await _iNotificationService.EditAsyncProvider(providerDto));

        #endregion

        #region Template
        [AllowAnonymous]
        [HttpGet("getalltemplate")]
        public async Task<IActionResult> GetByCodeAsyncTemplate()
        => Ok(await _iNotificationService.GetAllAsyncTemplate());

        [AllowAnonymous]
        [HttpGet("findtemplate")]
        public async Task<IActionResult> FindProviderTemplate([FromQuery] string code, [FromQuery] string chanel, [FromQuery] string institution)
         => Ok(await _iNotificationService.FindAsyncTemplate (code, chanel, institution));

        [AllowAnonymous]
        [HttpGet("gettemplatebycode")]
        public async Task<IActionResult> GetByCodeTemplate([FromQuery] string code, [FromQuery] string chanel, [FromQuery] string institution)
        => Ok(await _iNotificationService.GetByCodeAsyncTemplate(code, chanel, institution));

        [AllowAnonymous]
        [HttpGet("gettemplatebyid")]
        public async Task<IActionResult> GetByIdTemplate([FromQuery] int id)
            => Ok(await _iNotificationService.GetByIdAsyncTemplate(id));

        [AllowAnonymous]
        [HttpPost("addtemplate")]
        public async Task<IActionResult> AddTemplate([FromBody]TemplateDto templateDto) =>
           Ok(await _iNotificationService.AddAsyncTemplate(templateDto));

        [AllowAnonymous]
        [HttpPost("edittemplate")]
        public async Task<IActionResult> EditTemplate([FromBody]TemplateDto templateDto) =>
            Ok(await _iNotificationService.EditAsyncTemplate(templateDto));

        #endregion

        #region Campaign

        [AllowAnonymous]
        [HttpPost("addcampaign")]
        public async Task<IActionResult> AddCampaign([FromBody]CampaignDto campaignDto) =>
         Ok(await _iNotificationService.AddAsyncCampaign(campaignDto));

        #endregion


        #region Notification

        [AllowAnonymous]
        [HttpPost("addnotification")]
        public async Task<IActionResult> AddNotification([FromBody]NotificationsDto notificationsDto) =>
         Ok(await _iNotificationService.AddAsyncNotification(notificationsDto));

        #endregion

    }
}
