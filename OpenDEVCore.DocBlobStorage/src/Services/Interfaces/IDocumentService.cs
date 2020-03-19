using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OpenDEVCore.DocBlobStorage.Dto;

namespace OpenDEVCore.DocBlobStorage.Services
{
    public interface IDocumentService
    {
        Task<List<DocumentDto>> Add(List<DocumentDto> listDocDto, bool save);

        Task<List<DocumentNoDataDto>> GetByCodes(DocumentByCodesDto documentByCodes);

        Task<DocumentDto> GetDocumentById(int id);

        Task<DocumentDto> GetDocumentByCode(string codeDocument);

        Task<bool> FindByCode(string code, string institution);
         Task<MemoryStream> GetDocumentByType(string doctype, DocumentByCodesDto documentByCodes);



    }
}