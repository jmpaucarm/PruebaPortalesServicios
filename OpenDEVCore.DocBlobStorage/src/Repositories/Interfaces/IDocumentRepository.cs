using OpenDEVCore.DocBlobStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public interface IDocumentRepository
    {
        //registry
        Task<int> Add(Document ent);
        //Edit
        Task<Document> Edit(Document ent);
        //AddRange
        Task<List<Document>> AddRange(List<Document> ent);
        //lookup methods
        Task<bool> FindById(int idEnt);
        Task<bool> FindByCode(string code, string institution);
        Task<Document> GetById(int idEnt);
        Task<List<Document>> GetByCodes(List<KeyValuePair<string, string>> codes, string institution);
        Task<List<Document>> GetAll(string institution, bool active);





    }
}
