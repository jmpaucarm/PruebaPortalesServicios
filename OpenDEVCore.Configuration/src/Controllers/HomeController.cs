using Microsoft.AspNetCore.Mvc;
using Core.Mvc;

namespace OpenDEVCore.Configuration.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok("Configuration Api1");

    }
}
