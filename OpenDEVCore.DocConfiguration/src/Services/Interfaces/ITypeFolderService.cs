using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services
{

    public interface ITypeFolderService : ICRUD<TypeFolderDto>
    {
        Task<TypeFolderDto> GetByCode(string codeType, string institucion);

        Task<List<TypeFolderDto>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}