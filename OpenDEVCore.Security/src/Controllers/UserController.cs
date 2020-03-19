using System.Threading.Tasks;
using Core.Dispatchers;
using Core.Types;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Security.Dto;
using Core.RabbitMq;
using OpenDEVCore.Security.Services;
using OpenDEVCore.Security.Queries;
using Core.Mvc;
using Newtonsoft.Json;

namespace OpenDEVCore.Security.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, IDispatcher dispatcher, IBusPublisher busPublisher) : base(dispatcher, busPublisher)
        {
            _userService = userService;
        }

        [HttpGet("browseall")]
        public async Task<ActionResult<PagedResult<UserDto>>> BrowseAll([FromQuery] BrowseAllUsers query) =>
             Ok(await _userService.BrowseAllAsync(query));

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EditUserDto userDto)
           => Ok(await _userService.EditAsync(userDto));

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddUserDto userDto)
           => Ok(await _userService.AddAsync(userDto));

        [HttpGet("getuserprofiles")]
        public async Task<IActionResult> GetUserProfiles([FromQuery]UserGeneral userDto)
            => Ok(await _userService.GetUserProfilesAsync(userDto));

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery]UserGeneral query)
          => Ok(await _userService.GetAsync(query));

        [HttpGet("find")]
        public async Task<IActionResult> Find([FromQuery]UserGeneral userDto)
           => Ok(await _userService.FindAsync(userDto));

        [HttpGet("getByIds")]
        public async Task<IActionResult> GetByIds([FromQuery] int[] ids)
        {
            var users = await _userService.GetByIds(ids);
            var sr = JsonConvert.SerializeObject(users,Formatting.None,
            new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            return Ok(JsonConvert.DeserializeObject(sr));
        }

    }
}
