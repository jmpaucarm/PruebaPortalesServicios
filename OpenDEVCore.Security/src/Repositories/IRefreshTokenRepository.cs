using System.Threading.Tasks;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}