using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IESBEndPointExceptionRepository
    {
        Task<EsbendPointException> GetByErrorCodeAndEndPointCodeAsync(string endPointErrorCode, string endPointCode);
    }
}