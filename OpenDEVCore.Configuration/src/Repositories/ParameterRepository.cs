using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public class ParameterRepository :IParameterRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public ParameterRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }


        public async Task<bool> FindAsync(string code) =>
           await _ConfigurationSCContext.Parameter.AnyAsync(p => p.Code == code);

        public Task<Parameter> GetByIdAsync(int id) =>
            _ConfigurationSCContext.Parameter.AsNoTracking().SingleOrDefaultAsync(x => x.IdParameter == id);

        public Task<Parameter> GetAsync(string code) =>
            _ConfigurationSCContext.Parameter.AsNoTracking().SingleOrDefaultAsync(x => x.Code == code);

        public Task<List<Parameter>> GetAllAsync() =>
            _ConfigurationSCContext.Parameter.AsNoTracking().ToListAsync();

        public void Edit(Parameter parameter) =>
            _ConfigurationSCContext.Parameter.Update(parameter);

        public async Task AddAsync(Parameter parameter) =>
           await _ConfigurationSCContext.Parameter.AddAsync(parameter);


    }
}
