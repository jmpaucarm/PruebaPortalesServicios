using OpenDEVCore.DocBlobStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
     public  interface IDocumentFieldRepository
    {
        //registry
        Task<int> Add(DocumentField ent);
        //Edit
        Task<DocumentField> Edit(DocumentField ent);

        //lookup methods
        Task<bool> FindAsync(int idEnt);

        Task<DocumentField> GetByCode(string codeType, string institucion);

        Task<List<DocumentField>> GetAll(string institution, bool active);

        Task<List<Document>> GetByCodes(string institution, List<string> codes);

        Task<bool> Find(string code, string institution);

    }
}
