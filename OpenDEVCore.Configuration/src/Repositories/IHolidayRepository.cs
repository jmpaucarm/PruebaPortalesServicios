using OpenDEVCore.Configuration.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IHolidayRepository
    {
        Task<bool> FindAsync(DateTime dateHoliday, int idUbication);

        Task<Holiday> GetByDateAsync(DateTime dateHoliday, int idUbication);

        Task<Holiday> GetByIdAsync(int id);

        Task<List<Holiday>> GetAllAsync();

        void Edit(Holiday item);
        Task AddAsync(Holiday item);

    }
}
