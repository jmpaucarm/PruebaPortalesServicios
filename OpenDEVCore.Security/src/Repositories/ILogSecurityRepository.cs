using System.Threading.Tasks;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public interface ILogSecurityRepository
    {
        Task AddAsync(LogSecurity logSecurity);
    }
}
