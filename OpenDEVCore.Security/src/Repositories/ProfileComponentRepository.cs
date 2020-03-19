using OpenDEVCore.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenDEVCore.Security.Repositories
{
    public class ProfileComponentRepository : IProfileComponentRepository
    {

        private readonly SecurityDBContext _securityDbContext;
        public ProfileComponentRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }


        public async Task<List<ProfileComponent>> GetProfileComponentsByProfileId(int profileId)
        {
            return await _securityDbContext.ProfileComponent
                .Include(p => p.IdComponentNavigation.IdOptionNavigation)
                .AsNoTracking()
                .Where(p => p.IdProfile.Equals(profileId)).ToListAsync();
        }

        public async Task<List<ProfileComponent>> GetProfileComponentsByProfileCode(string profileCode)
        {
            return await _securityDbContext.ProfileComponent
                .Include(p => p.IdComponentNavigation.IdOptionNavigation)
                .Include(p => p.IdProfileNavigation)
                .AsNoTracking()
                .Where(p => p.IdProfileNavigation.ProfileCode.Equals(profileCode)).ToListAsync();
        }
    }
}
