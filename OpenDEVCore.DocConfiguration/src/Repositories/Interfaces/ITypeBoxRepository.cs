using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface ITypeBoxRepository : ICRUD<TypeBox>
    {
        Task<TypeBox> GetByCode(string codeType, string institucion);

        Task<List<TypeBox>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);



    }
}
