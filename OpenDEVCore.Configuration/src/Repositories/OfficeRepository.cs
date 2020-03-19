using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Configuration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Repositories
{
    public class OfficeRepository :IOfficeRepository
    {

        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public OfficeRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }

        public async Task<List<Office>> GetOffices(int[] ids) {
            return await _ConfigurationSCContext.Office.AsNoTracking().Where(x => ids.Contains(x.IdOffice)).ToListAsync();
        }


    }
}
