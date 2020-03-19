using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface ITypeImageRepository : ICRUD<TypeImage>
    {
        Task<TypeImage> GetByCode(string codeType, string institucion);

        Task<List<TypeImage>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);

    }
}