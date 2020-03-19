using System;
using System.Linq;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public HolidayRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }

        public async Task<bool> FindAsync(DateTime dateHoliday, int idUbication) =>
             await _ConfigurationSCContext.Holiday.AnyAsync(p => p.DateHoliday == dateHoliday && p.IdGeographicLocation2 == idUbication);
            
        public async Task<Holiday> GetByDateAsync(DateTime dateHoliday, int idUbication) =>
            await _ConfigurationSCContext.Holiday.AsNoTracking().SingleOrDefaultAsync(p => p.DateHoliday == dateHoliday && p.IdGeographicLocation2 == idUbication);

        public async Task<Holiday> GetByIdAsync(int id) =>
            await _ConfigurationSCContext.Holiday.AsNoTracking().SingleOrDefaultAsync(p => p.IdHoliday == id);

        public async Task<List<Holiday>> GetAllAsync() =>
            await _ConfigurationSCContext.Holiday.AsNoTracking().ToListAsync();


        public void Edit(Holiday holiday) =>
            _ConfigurationSCContext.Holiday.Update(holiday);

        public async Task AddAsync(Holiday holiday) =>
            await _ConfigurationSCContext.Holiday.AddAsync(holiday);


    }
}
