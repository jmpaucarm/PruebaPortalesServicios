using OpenDevCore.DocConfiguration;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories.DataBaseElements
{
    public class AppConfigurationRepository : IAppConfigurationRepository
    {
        private readonly DocConfigurationContext _configurationContext;

        public AppConfigurationRepository(DocConfigurationContext configurationContext)
        {
            _configurationContext = configurationContext;
        }

        public async  Task<bool> SaveAsync()
        {
            try
            {
                return (await _configurationContext.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                _configurationContext.Reset();
                throw ex;
            }
        }
    }
}
