
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface ITypeBoxService : ICRUD<TypeBoxDto>
    {
        Task<TypeBoxDto> GetByCode(string codeType, string institucion);

        Task<List<TypeBoxDto>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}
