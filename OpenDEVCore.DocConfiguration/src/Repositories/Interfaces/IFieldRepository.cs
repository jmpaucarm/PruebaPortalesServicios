using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface IFieldRepository : ICRUD<Field>
    {
        Task<Field> GetByCode(string codeType, string institucion);

        Task<List<Field>> GetAll(string institution, bool active);


        Task<bool> Find(string code, string institution);
        Task<Field> GetCodeByID(int id);


    }
}