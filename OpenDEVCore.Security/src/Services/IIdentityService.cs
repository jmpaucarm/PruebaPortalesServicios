using System.Threading.Tasks;
using Core.Authentication;

namespace OpenDEVCore.Security.Services
{
    public interface IIdentityService
    {
        Task<bool> MetricsLogAsync(string userCode);

        Task<object> SignInAsync(string userCode, string password, string station);
        Task<object> SignInFromPortalAsync(string encodedCredentials, string station);

        Task SignOutAsync(string userCode);

        Task<bool> ChangePasswordAsync(string userCode, string currentPassword, string newPassword);

        Task<object> ConnectAsync(string userCode, int office, int profile, string profileCode, string station);
    }
}
