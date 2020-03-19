using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface ITypeFolderRepository : ICRUD<TypeFolder>
    {
        Task<TypeFolder> GetByCode(string codeType, string institucion);

        Task<List<TypeFolder>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}