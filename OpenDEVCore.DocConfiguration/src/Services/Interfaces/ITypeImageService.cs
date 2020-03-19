
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services
{

    public interface ITypeImageService : ICRUD<TypeImageDto>
    {
        Task<TypeImageDto> GetByCode(string codeType, string institucion);

        Task<List<TypeImageDto>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);

    }
}