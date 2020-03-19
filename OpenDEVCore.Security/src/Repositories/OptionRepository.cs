using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Security.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public OptionRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public async Task<List<Option>> GetAllAsync() =>
            await _securityDbContext.Option.AsNoTracking().ToListAsync();

        public async Task AddAsync(Option option) => await _securityDbContext.Option.AddAsync(option);
    }
}
