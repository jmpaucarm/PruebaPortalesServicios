using OpenDEVCore.Configuration.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OpenDEVCore.Configuration.Services
{
    public interface IHolidayService
    {
        Task<bool> FindHolidayAsync(DateTime holiday, int idUbication);
        Task<HolidayDto> GetByDateAsync(DateTime holiday, int idUbication);
        Task<HolidayDto> GetByIdAsync(int id);
        Task<List<HolidayDto>> GetAllAsync();

        Task<bool> EditAsync(HolidayDto ctlgDto);
        Task<int> AddAsync(HolidayDto ctlgDto);
    }
}
