using Core.Types;
using OpenDEVCore.DocBlobStorage.Dto;
using RestEase;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Proxy
{
    public interface ITypeFolderService
    {

        [AllowAnyStatusCode]
        [Get("TypeFolder/getconfigurations")]
        Task<CoreResponse<TypeFolderDto>>lista1([Query]string code, [Query] string institution);
    }
}
