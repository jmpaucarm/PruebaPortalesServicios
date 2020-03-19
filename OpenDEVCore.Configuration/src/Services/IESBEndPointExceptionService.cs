using System.Threading.Tasks;
using Core.Exceptions;
using OpenDEVCore.Configuration.Dto;

namespace OpenDEVCore.Configuration.Services
{
    public interface IESBEndPointExceptionService
    {
        Task<ResourceExDescription> GetByErrorCodeAndEndPointCodeAsync(string endPointErrorCode, string endPointCode);
    }
}