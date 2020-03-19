using System.Threading.Tasks;
using Core.Dispatchers;
using Microsoft.AspNetCore.Mvc;
using Core.RabbitMq;
using Core.Mvc;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Controllers
{
    public class OptionController : BaseController
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService, IDispatcher dispatcher, IBusPublisher busPublisher) : base(dispatcher, busPublisher)
        {
            _optionService = optionService;
        }

        [HttpGet("getalloptions")]
        public async Task<IActionResult> GetAllOptions() => Ok(await _optionService.GetAllAsync());

    }
}
