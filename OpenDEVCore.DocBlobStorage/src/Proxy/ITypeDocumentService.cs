using Core.Mvc;
using Core.Types;
using OpenDEVCore.DocBlobStorage.Dto;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Proxy
{
    public interface ITypeDocumentService : IProxy
    {

        [AllowAnyStatusCode]
        [Get("TypeDocument/getbycode")]
        Task<CoreResponse<TypeDocumentDto>> GetByCode([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeDocument/getconfigurations")]
        Task<CoreResponse<List<TypeDocumentDto>>> GetConfigurations([Query]string institution, [Query] string[] codes);

    }
}
