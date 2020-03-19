using OpenDevCore.DocConfiguration.Entities;
using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface ITypeDocumentRepository :ICRUD<TypeDocument>
    {
        Task<TypeDocument> GetByCode(string codeType, string  institucion );

        Task<List<TypeDocument>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);

        Task<List<TypeDocument>> GetConfigurations(List<string> codigos, string institucion);
        Task<List<TypeDocument>> GetAllForm(string institution, bool isForm);
    }
}