using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class OfficeController : BaseController
    {
        private readonly IOfficeService _iOfficeService;

        public OfficeController(IOfficeService iOfficeService)
        {
            _iOfficeService = iOfficeService;
        }


        [HttpGet("getGetOffices")]
        public async Task<IActionResult> GetOffices([FromQuery] int[] ids)
           => Ok(await _iOfficeService.GetOffices(ids));
    }
}
