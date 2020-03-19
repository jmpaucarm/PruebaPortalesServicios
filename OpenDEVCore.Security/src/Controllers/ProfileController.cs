using System.Threading.Tasks;
using Core.Dispatchers;
using Microsoft.AspNetCore.Mvc;
using Core.RabbitMq;
using OpenDEVCore.Security.Services;
using Core.Mvc;
using OpenDEVCore.Security.Dto;

namespace OpenDEVCore.Security.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService, IDispatcher dispatcher, IBusPublisher busPublisher) : base( dispatcher, busPublisher)
        {
            _profileService = profileService;
        }
       
        [HttpGet("getallprofiles")]
        public async Task<IActionResult> GetAll()
           => Ok(await _profileService.GetAllAsync());

        [HttpGet("findprofilebycode")]
        public async Task<IActionResult> FindProfileByCode([FromQuery] string code, [FromQuery] int idInstitution)
         => Ok(await _profileService.FindByCodeAsync(code, idInstitution));

        [HttpGet("getprofilebycode")]
        public async Task<IActionResult> GetByCode([FromQuery] string code, [FromQuery] int idInstitution)
          => Ok(await _profileService.GetByCodeInstitutionAsync(code, idInstitution));

        [HttpGet("getprofilebyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
            => Ok(await _profileService.GetByIdAsync(id));

        [HttpPost("addprofile")]
        public async Task<IActionResult> Add(AddProfileDto ctlgoDto) =>
            Ok(await _profileService.AddAsync(ctlgoDto));

        [HttpPost("editprofile")]
        public async Task<IActionResult> Edit(EditProfileDto ctlgoDto) =>
            Ok(await _profileService.EditAsync(ctlgoDto));

    }
}
