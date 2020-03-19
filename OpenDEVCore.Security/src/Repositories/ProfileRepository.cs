using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public ProfileRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public async Task<List<Profile>> GetAllAsync() =>
            await _securityDbContext.Profile.AsNoTracking().ToListAsync();
        

        public async Task<bool> FindAsync(string code, int idInstitution) =>
           await _securityDbContext.Profile.AsNoTracking().AnyAsync(x => x.ProfileCode == code && x.IdInstitution == idInstitution);

        public Task<Profile> GetByCodeInstitutionAsync(string code, int idInstitution) =>
        _securityDbContext.Profile.Include(y => y.ProfileOption).AsNoTracking().SingleOrDefaultAsync(x => x.ProfileCode == code && x.IdInstitution == idInstitution);


        public Task<Profile> GetByCodeAsync(string code) =>
            _securityDbContext.Profile.AsNoTracking().SingleOrDefaultAsync(x => x.ProfileCode == code);

        public Task<Profile> GetByIdAsync(int id) =>
            _securityDbContext.Profile.Include(y => y.ProfileOption).ThenInclude(i=>i.IdOptionNavigation).AsNoTracking().SingleOrDefaultAsync(x => x.IdProfile == id);
        
        
        public Profile Edit(Profile profile)
        {
            _securityDbContext.Profile.Update(profile);
            return profile;
        }

        public async Task AddAsync(Profile profile) =>
            await _securityDbContext.Profile.AddAsync(profile);
    }
}
