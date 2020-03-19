using System.Threading.Tasks;

namespace OpenDEVCore.Security.Repositories
{
    public interface ISecurityRepository
    {
        Task<bool> SaveAsync();
    }
}
