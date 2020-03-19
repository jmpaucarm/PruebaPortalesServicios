using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public class DocumentFieldRepository : IDocumentFieldRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;
        private readonly IAppBlodStorageRepository _appBlodStorageRepository;

        public DocumentFieldRepository(DocBlodStorageContext docBlodStorageContext, IAppBlodStorageRepository appBlodStorageRepository)
        {
            _docBlodStorageContext = docBlodStorageContext;
            _appBlodStorageRepository = appBlodStorageRepository;
        }

        public async  Task<int> Add(DocumentField ent)
        {
            await _docBlodStorageContext.AddAsync(ent);
            await _appBlodStorageRepository.SaveAsync();
            return ent.IdDocumentField;
        }


        public Task<DocumentField> Edit(DocumentField ent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Find(string code, string institution)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindAsync(int idEnt)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindByCodes(string institution, List<string> codes)
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentField>> GetAll(string institution, bool active)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentField> GetByCode(string codeType, string institucion)
        {
            throw new NotImplementedException();
        }

        public Task<List<Document>> GetByCodes(string institution, List<string> codes)
        {
            throw new NotImplementedException();
        }
    }
}
