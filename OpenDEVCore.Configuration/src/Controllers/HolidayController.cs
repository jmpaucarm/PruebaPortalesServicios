using System;
using System.Threading.Tasks;
using Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Services;

namespace OpenDEVCore.Configuration.Controllers
{
    public class HolidayController : BaseController
    {
        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }


        [HttpGet("getholidaybydate")]
        public async Task<IActionResult> GetByDate([FromQuery] long holidaydate, [FromQuery] int idUbication)
        {
            DateTime holiDay = Convert.ToDateTime(holidaydate);
            return Ok(await _holidayService.GetByDateAsync(holiDay, idUbication));
        }
        

        [HttpGet("findholiday")]
        public async Task<IActionResult> FindByDate([FromQuery] long holidaydate, [FromQuery] int idUbication)
        {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                DateTime holiDay = dtDateTime.AddSeconds(holidaydate).ToLocalTime().Date;
                return Ok(await _holidayService.FindHolidayAsync(holiDay, idUbication));
            
            
        }


        [HttpGet("getholidaybyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
            => Ok(await _holidayService.GetByIdAsync(id));


        [HttpGet("getallholidays")]
        public async Task<IActionResult> GetAll()
         => Ok(await _holidayService.GetAllAsync());

        [HttpPost("addholiday")]
        public async Task<IActionResult> Add(HolidayDto holidayDto) =>
           Ok(await _holidayService.AddAsync(holidayDto));

        [HttpPost("editholiday")]
        public async Task<IActionResult> Edit(HolidayDto holidayDto) =>
            Ok(await _holidayService.EditAsync(holidayDto));
    }
}
