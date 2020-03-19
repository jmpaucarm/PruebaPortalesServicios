using System.Threading.Tasks;
using Core.Dispatchers;
using Microsoft.AspNetCore.Mvc;
using Core.RabbitMq;
using OpenDEVCore.Security.Services;
using Core.Mvc;
using OpenDEVCore.Security.Dto;

namespace OpenDEVCore.Security.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService, IDispatcher dispatcher, IBusPublisher busPublisher) : base(dispatcher, busPublisher)
        {
            _menuService = menuService;
        }

        [HttpGet("getallmenus")]
        public async Task<IActionResult> GetAll() => Ok(await _menuService.GetAllAsync());


        [HttpPost("editmenu")]
        public async Task<IActionResult> Edit(MenuDto menuDto) =>
            Ok(await _menuService.EditAsync(menuDto));

        [HttpGet("getallmenuscreens")]
        public async Task<IActionResult> GetAllScreens() => Ok(await _menuService.GetAllScreensAsync());

        [HttpPost("addmenu")]
        public async Task<IActionResult> Add(MenuDto menuDto) => Ok(await _menuService.AddAsync(menuDto));
    }
}
