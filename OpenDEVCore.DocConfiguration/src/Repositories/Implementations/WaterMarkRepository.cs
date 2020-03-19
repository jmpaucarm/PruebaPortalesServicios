
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class WaterMarkRepository : IWaterMarkRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public WaterMarkRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }
        public async Task<int> Add(WaterMark ent)
        {
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdWaterMark;
        }

        public async Task<bool> Edit(WaterMark ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.WaterMark.AsNoTracking().
                           AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.WaterMark.AsNoTracking().
               AnyAsync(p => p.IdWaterMark.Equals(idEnt)));
        }

        public async Task<List<WaterMark>> GetAll(string institution, bool active)
        {
            return await _docConfigurationContext.WaterMark.
                AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();


        }

        public async Task<WaterMark> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.WaterMark.AsNoTracking()
                          .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }

        public async Task<WaterMark> GetById(int id)
        {
            return (await _docConfigurationContext.WaterMark.AsNoTracking()
                           .FirstOrDefaultAsync(p => p.IdWaterMark.Equals(id)));
        }
    }
}
