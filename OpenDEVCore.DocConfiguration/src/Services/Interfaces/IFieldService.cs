
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services
{

    public interface IFieldService : ICRUD<FieldDto>
    {
        Task<FieldDto> GetByCode(string codeType, string institucion);

        Task<List<FieldDto>> GetAll(string institution, bool active);



        Task<bool> Find(string code, string institution);

        Task<string> GetCodeByID(int id);
    }
}