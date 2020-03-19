using System.Threading.Tasks;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public class LogSecurityRepository : ILogSecurityRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public LogSecurityRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }
        
        public async Task AddAsync(LogSecurity log)
        {
            await _securityDbContext.LogSecurity.AddAsync(log);
        }
    }
}
