using Core.Data;
using System;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public SecurityRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _securityDbContext.SaveChangesAsync() >= 0);
            }
            catch (Exception e)
            {
                _securityDbContext.Reset();
                throw e;
            }
        }

        public bool Save()
        {
            try
            {
                return ( _securityDbContext.SaveChanges() >= 0);
            }
            catch (Exception e)
            {
                _securityDbContext.Reset();
                throw e;
            }
        }

    }
}
