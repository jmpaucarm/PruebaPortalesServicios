using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        /// <summary>
        /// Ejemplo de Metricas
        /// </summary>
        /// <param name="cmnd"> Parametro comando</param>
        /// <returns>OK</returns>
        [HttpPost("metriclog/{UserCode}")]
        public async Task<IActionResult> MetricLog([FromRoute] string cmnd) =>
            Ok(await _identityService.MetricsLogAsync(cmnd));

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserGeneral userDto) =>
            Ok(await _identityService.SignInAsync(userDto.UserCode, userDto.Password, userDto.Station));

        [HttpPost("signinfromportal")]
        public async Task<IActionResult> SignInFromPortal(UserGeneral userDto) =>
            Ok(await _identityService.SignInFromPortalAsync(userDto.Password, userDto.Station));

        //[HttpPost("signout")]
        //public async Task<IActionResult> SignOut(UserGeneral userDto)
        //{
        //    await _identityService.SignOutAsync(userDto.UserCode);
        //    return NoContent();
        //}

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(UserGeneral userDto)
        => Ok(await _identityService.ChangePasswordAsync(userDto.UserCode, userDto.Password, userDto.NewPassword));


        [HttpPost("connect")]
        public async Task<IActionResult> Connect(UserGeneral userDto)
        => Ok(await _identityService.ConnectAsync(userDto.UserCode, userDto.Office, userDto.Profile, userDto.ProfileCode ,userDto.Station));
        }
}
