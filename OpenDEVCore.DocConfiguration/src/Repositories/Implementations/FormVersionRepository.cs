using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class FormVersionRepository : IFormVersionRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public FormVersionRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;

        }
        public async Task<int> Add(FormVersion ent)
        {
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdFormVersion;

        }

        public async Task<bool> Edit(FormVersion ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.FormVersion.AsNoTracking().
                AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));

        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.FormVersion.AsNoTracking().
                AnyAsync(p => p.IdFormVersion.Equals(idEnt)));
        }

        public async Task<List<FormVersion>> GetAll(string institution, bool active)
        {
            return await _docConfigurationContext.FormVersion.
                AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();

        }

        public async Task<FormVersion> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.FormVersion.AsNoTracking()
              .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }
    }
}
