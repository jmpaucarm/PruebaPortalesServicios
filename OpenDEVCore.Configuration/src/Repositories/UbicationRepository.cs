using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OpenDEVCore.Configuration.Repositories
{
    public class UbicationRepository : IUbicationRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public UbicationRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }

        public Task<List<GeographicLocation1>> GetAllLocation1() =>
            _ConfigurationSCContext.GeographicLocation1.AsNoTracking().ToListAsync();
        
        public Task<GeographicLocation1> GetByCodeLocation1Async(string code)=>
        _ConfigurationSCContext.GeographicLocation1.Include(y => y.GeographicLocation2).AsNoTracking().SingleOrDefaultAsync(x => x.GeographicLocation1Code == code);

        public Task<GeographicLocation1> GetByIdLocation1Async(int id) =>
            _ConfigurationSCContext.GeographicLocation1.Include(y => y.GeographicLocation2).AsNoTracking().SingleOrDefaultAsync(x => x.IdGeographicLocation1 == id);

        public void EditLocation1(GeographicLocation1 geographicLocation) =>
            _ConfigurationSCContext.GeographicLocation1.Update(geographicLocation);

        public async Task AddLocation1Async(GeographicLocation1 geographicLocation) =>
            await _ConfigurationSCContext.GeographicLocation1.AddAsync(geographicLocation);


        public Task<List<GeographicLocation2>> GetAllLocation2(int id) =>
            _ConfigurationSCContext.GeographicLocation2.Where(x => x.IdGeographicLocation1 == id).ToListAsync();

        public Task<List<GeographicLocation2>> GetAllLocation2ByCode(string code) =>
       _ConfigurationSCContext.GeographicLocation2.Where(x => x.IdGeographicLocation1Navigation.GeographicLocation1Code == code).ToListAsync();

        public async  Task<List<GeographicLocation2>> GetAllOnlyLocation2() =>
        await _ConfigurationSCContext.GeographicLocation2.AsNoTracking().ToListAsync();
        public async Task<List<GeographicLocation3>> GetAllOnlyLocation3() =>
        await _ConfigurationSCContext.GeographicLocation3.AsNoTracking().ToListAsync();
        public async Task<List<GeographicLocation4>> GetAllOnlyLocation4() =>
        await _ConfigurationSCContext.GeographicLocation4.AsNoTracking().ToListAsync();


        public Task<GeographicLocation2> GetByCodeLocation2Async(string code) =>
           _ConfigurationSCContext.GeographicLocation2.Include(y => y.GeographicLocation3).AsNoTracking().SingleOrDefaultAsync(x => x.GeographicLocation2Code == code);

        public Task<GeographicLocation2> GetByIdLocation2Async(int id) =>
            _ConfigurationSCContext.GeographicLocation2.Include(y => y.GeographicLocation3).AsNoTracking().SingleOrDefaultAsync(x => x.IdGeographicLocation2 == id);

        public void EditLocation2(GeographicLocation2 geographicLocation) =>
            _ConfigurationSCContext.GeographicLocation2.Update(geographicLocation);

        public async Task AddLocation2Async(GeographicLocation2 geographicLocation) =>
            await _ConfigurationSCContext.GeographicLocation2.AddAsync(geographicLocation);



        public Task<List<GeographicLocation3>> GetAllLocation3(int id) =>
           _ConfigurationSCContext.GeographicLocation3.Where(x => x.IdGeographicLocation2 == id).ToListAsync();

        public Task<GeographicLocation3> GetByCodeLocation3Async(string code) =>
           _ConfigurationSCContext.GeographicLocation3.Include(y => y.GeographicLocation4).AsNoTracking().SingleOrDefaultAsync(x => x.GeographicLocation3Code == code);

        public Task<GeographicLocation3> GetByIdLocation3Async(int id) =>
            _ConfigurationSCContext.GeographicLocation3.Include(y => y.GeographicLocation4).AsNoTracking().SingleOrDefaultAsync(x => x.IdGeographicLocation3 == id);

        public void EditLocation3(GeographicLocation3 geographicLocation) =>
            _ConfigurationSCContext.GeographicLocation3.Update(geographicLocation);

        public async Task AddLocation3Async(GeographicLocation3 geographicLocation) =>
            await _ConfigurationSCContext.GeographicLocation3.AddAsync(geographicLocation);



        public Task<List<GeographicLocation4>> GetAllLocation4(int id) =>
          _ConfigurationSCContext.GeographicLocation4.Where(x => x.IdGeographicLocation3 == id).ToListAsync();

        public Task<GeographicLocation4> GetByCodeLocation4Async(string code) =>
           _ConfigurationSCContext.GeographicLocation4.AsNoTracking().SingleOrDefaultAsync(x => x.GeographicLocation4Code == code);

        public Task<GeographicLocation4> GetByIdLocation4Async(int id) =>
            _ConfigurationSCContext.GeographicLocation4.AsNoTracking().SingleOrDefaultAsync(x => x.IdGeographicLocation4 == id);

        public void EditLocation4(GeographicLocation4 geographicLocation) =>
            _ConfigurationSCContext.GeographicLocation4.Update(geographicLocation);

        public async Task AddLocation4Async(GeographicLocation4 geographicLocation) =>
            await _ConfigurationSCContext.GeographicLocation4.AddAsync(geographicLocation);

        public Task<List<GeographicLocation3>> GetAllLocation3ByCode(string code) =>
            _ConfigurationSCContext.GeographicLocation3.Where(x => x.IdGeographicLocation2Navigation.GeographicLocation2Code == code).ToListAsync();
        

        public Task<List<GeographicLocation4>> GetAllLocation4ByCode(string code) =>
            _ConfigurationSCContext.GeographicLocation4.Where(x => x.IdGeographicLocation3Navigation.GeographicLocation3Code == code).ToListAsync();
        
    }
}
