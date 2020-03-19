using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class ESBEndPointExceptionController : BaseController
    {

        private readonly IESBEndPointExceptionService _iESBEndPointExceptionService;

        public ESBEndPointExceptionController(IESBEndPointExceptionService iESBEndPointExceptionService)
        {
            _iESBEndPointExceptionService = iESBEndPointExceptionService;
        }


        [HttpGet("Map")]
        public async Task<IActionResult> GetByErrorCodeAndEndPointCodeAsync([FromQuery]string endPointErrorCode, [FromQuery] string endPointCode)
        {
            return Ok(await _iESBEndPointExceptionService.GetByErrorCodeAndEndPointCodeAsync(endPointErrorCode, endPointCode));
        }



    }
}
