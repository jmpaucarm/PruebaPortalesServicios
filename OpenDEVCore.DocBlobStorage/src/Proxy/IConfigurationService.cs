using Core.Mvc;
using Core.Types;
using OpenDEVCore.DocBlobStorage.Dto;
using RestEase;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Proxy
{
    public interface IConfigurationService :IProxy
    {


        [AllowAnyStatusCode]
        [Get("Parameter/getparameterbycode")]
        Task<CoreResponse<ParameterDto>> GetByCodeAsync([Query] string code);


    }
}
