using System.Linq;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public InstitutionRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }

        
        public async Task<bool> FindAsync(string ruc) =>
           await _ConfigurationSCContext.Institution.AnyAsync(p => p.Ruc == ruc);

        public Task<Institution> GetByCodeAsync(string code)
        {
           return _ConfigurationSCContext.Institution.Include(y => y.Office).AsNoTracking().SingleOrDefaultAsync(x => x.Ruc == code);
        }


        public async Task<Institution> GetByIdAsync(int code)
        {
           return await _ConfigurationSCContext.Institution.Include(y => y.Office).AsNoTracking().SingleOrDefaultAsync(x => x.IdInstitution == code);           
        }

        public Task<List<Institution>> AllAsync(bool onlyActive, bool onlyInstitution)
        {

            if (onlyInstitution) // solo institu¿cion
            {
                if (onlyActive)
                    return _ConfigurationSCContext.Institution.Where(x => x.IsActive == true).AsNoTracking().ToListAsync(); 
                else
                    return _ConfigurationSCContext.Institution.AsNoTracking().ToListAsync();
            }
            else
            {
                if (onlyActive)
                    return _ConfigurationSCContext.Institution.Where(x => x.IsActive == true).Include(y => y.Office).AsNoTracking().ToListAsync();
                else
                    return _ConfigurationSCContext.Institution.Include(y => y.Office).AsNoTracking().ToListAsync();
            }
            
        }

        public async Task AddAsync(Institution item) =>
            await _ConfigurationSCContext.Institution.AddAsync(item);

        public Institution Edit(Institution instititution)
        {
            _ConfigurationSCContext.Institution.Update(instititution);
            return instititution;
        }
    }
}
