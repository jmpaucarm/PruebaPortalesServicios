using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface  IConfigurationRepository
    {
        Task<bool> SaveAsync();
    }
}
