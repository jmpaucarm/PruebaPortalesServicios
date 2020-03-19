using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class UbicationController : BaseController
    {
        private readonly IUbicationService _ubicationService;

        public UbicationController(IUbicationService ubicationService)
        {
            _ubicationService = ubicationService;
        }

        [HttpGet("getAllGeographicLocations")]
        public async Task<IActionResult> GetAllGeographicLocations()
        => Ok(await _ubicationService.GetAllGeographicLocations());

        [HttpGet("getalllocation1")]
        public async Task<IActionResult> GetAllLocation1()
          => Ok(await _ubicationService.GetAllLocation1());

        [HttpGet("getbycodelocation1")]
        public async Task<IActionResult> GetByCodeLocation1([FromQuery]string code)
            => Ok(await _ubicationService.GetByCodeLocation1Async(code));

        [HttpGet("getbyidlocation1")]
        public async Task<IActionResult> GetByIdLocation1([FromQuery]int id)
            => Ok(await _ubicationService.GetByIdLocation1Async(id));

        [HttpPost("addlocation1")]
        public async Task<IActionResult> Add(GeographicLocation1Dto geographicLocationDto) =>
          Ok(await _ubicationService.AddLocation1Async(geographicLocationDto));

        [HttpPost("editlocation1")]
        public async Task<IActionResult> Edit(GeographicLocation1Dto geographicLocationDto) =>
            Ok(await _ubicationService.EditLocation1Async(geographicLocationDto));


        [HttpGet("getalllocation2")]
        public async Task<IActionResult> GetAllLocation2(int id)
          => Ok(await _ubicationService.GetAllLocation2(id));


        [HttpGet("getalllocation2ByCode")]
        public async Task<IActionResult> Getalllocation2ByCode(string code)
          => Ok(await _ubicationService.GetAllLocation2ByCode(code));

        [HttpGet("getallonlylocation2")]
        public async Task<IActionResult> GetOnlyAllLocation2()
          => Ok(await _ubicationService.GetAllOnlyLocation2());


        [HttpGet("getbycodelocation2")]
        public async Task<IActionResult> GetByCodeLocation2([FromQuery]string code)
            => Ok(await _ubicationService.GetByCodeLocation2Async(code));

        [HttpGet("getbyidlocation2")]
        public async Task<IActionResult> GetByIdLocation2([FromQuery]int id)
            => Ok(await _ubicationService.GetByIdLocation2Async(id));

        [HttpPost("addlocation2")]
        public async Task<IActionResult> Add(GeographicLocation2Dto geographicLocationDto) =>
          Ok(await _ubicationService.AddLocation2Async(geographicLocationDto));

        [HttpPost("editlocation2")]
        public async Task<IActionResult> Edit(GeographicLocation2Dto geographicLocationDto) =>
            Ok(await _ubicationService.EditLocation2Async(geographicLocationDto));



        [HttpGet("getalllocation3")]
        public async Task<IActionResult> GetAllLocation3(int id)
          => Ok(await _ubicationService.GetAllLocation3(id));

        [HttpGet("getalllocation3ByCode")]
        public async Task<IActionResult> Getalllocation3ByCode(string code)
        => Ok(await _ubicationService.GetAllLocation3ByCode(code));

        [HttpGet("getbycodelocation3")]
        public async Task<IActionResult> GetByCodeLocation3([FromQuery]string code)
            => Ok(await _ubicationService.GetByCodeLocation3Async(code));

        [HttpGet("getbyidlocation3")]
        public async Task<IActionResult> GetByIdLocation3([FromQuery]int id)
            => Ok(await _ubicationService.GetByIdLocation3Async(id));

        [HttpPost("addlocation3")]
        public async Task<IActionResult> Add(GeographicLocation3Dto geographicLocationDto) =>
          Ok(await _ubicationService.AddLocation3Async(geographicLocationDto));

        [HttpPost("editlocation3")]
        public async Task<IActionResult> Edit(GeographicLocation3Dto geographicLocationDto) =>
            Ok(await _ubicationService.EditLocation3Async(geographicLocationDto));



        [HttpGet("getalllocation4")]
        public async Task<IActionResult> GetAllLocation4(int id)
         => Ok(await _ubicationService.GetAllLocation4(id));

        [HttpGet("getalllocation4ByCode")]
        public async Task<IActionResult> Getalllocation4ByCode(string code)
     => Ok(await _ubicationService.GetAllLocation4ByCode(code));

        [HttpGet("getbycodelocation4")]
        public async Task<IActionResult> GetByCodeLocation4([FromQuery]string code)
            => Ok(await _ubicationService.GetByCodeLocation4Async(code));

        [HttpGet("getbyidlocation4")]
        public async Task<IActionResult> GetByIdLocation4([FromQuery]int id)
            => Ok(await _ubicationService.GetByIdLocation4Async(id));

        [HttpPost("addlocation4")]
        public async Task<IActionResult> Add(GeographicLocation4Dto geographicLocationDto) =>
          Ok(await _ubicationService.AddLocation4Async(geographicLocationDto));

        [HttpPost("editlocation4")]
        public async Task<IActionResult> Edit(GeographicLocation4Dto geographicLocationDto) =>
            Ok(await _ubicationService.EditLocation4Async(geographicLocationDto));
    }
}
