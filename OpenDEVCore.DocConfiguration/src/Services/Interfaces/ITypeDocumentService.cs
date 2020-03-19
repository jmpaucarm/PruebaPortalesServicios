using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services
{

    public interface ITypeDocumentService : ICRUD<TypeDocumentDto>
    {
        Task<TypeDocumentDto> GetByCode(string codeType, string institucion);

        Task<List<TypeDocumentDto>> GetAll(string institution, bool active);


        Task<bool> Find(string code, string institution);

        Task<List<TypeDocumentDto>> GetConfigurations(List<string> codigos, string institucion);

        Task<List<TypeDocumentDto>> GetAllForm(string institution, bool isForm);
    }
}