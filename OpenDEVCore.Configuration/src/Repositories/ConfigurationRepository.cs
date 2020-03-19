using System;
using System.Threading.Tasks;


namespace OpenDEVCore.Configuration.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;
        public ConfigurationRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _ConfigurationSCContext.SaveChangesAsync() >= 0);
            }
            catch (Exception e)
            {
                _ConfigurationSCContext.Reset();
                throw e;
            }
        }

    }
}
