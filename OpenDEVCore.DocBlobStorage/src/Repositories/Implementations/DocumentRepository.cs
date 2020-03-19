using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;
        private readonly IAppBlodStorageRepository _appBlodStorageRepository;
        public DocumentRepository(DocBlodStorageContext docBlodStorageContext, IAppBlodStorageRepository appBlodStorageRepository)
        {
            _docBlodStorageContext = docBlodStorageContext;
            _appBlodStorageRepository = appBlodStorageRepository;
        }

        public async Task<int> Add(Document ent)
        {
            await _docBlodStorageContext.AddAsync(ent);
            await _appBlodStorageRepository.SaveAsync();
            return ent.IdDocument;
        }

        public async Task<List<Document>> AddRange(List<Document> listEnt)
        {
            await _docBlodStorageContext.AddRangeAsync(listEnt);
            await _appBlodStorageRepository.SaveAsync();
            return listEnt;

        }

        public Task<Document> Edit(Document ent)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindByCode(string code, string institution)
        {
            return await _docBlodStorageContext.Document.AnyAsync(pp => pp.CodeDocument.Equals(code) && pp.Institution.Equals(institution));

        }

        public Task<bool> FindById(int idEnt)
        {
            throw new NotImplementedException();
        }

        public Task<List<Document>> GetAll(string institution, bool active)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Document>> GetByCodes(List<KeyValuePair<string, string>> codes, string institution)
        {
            var llaves = codes.Select(pp => pp.Key).ToList();
            var valor = codes.Select(pp => pp.Value).ToList();

            //obtener la lista de los ids Filtrados por palabras clave  
            var result = _docBlodStorageContext.DocumentField.Include(xx => xx.IdDocumentNavigation).Where(pp =>
            (llaves.Contains(pp.CodeField) && valor.Contains(pp.Value))
            ).ToList()
            .GroupBy(x => x.IdDocument)
            .Select(s => new
            {
                IdDocument = (int)s.Key,
                DocumentField = _docBlodStorageContext.DocumentField.Where(e => e.IdDocument.Equals(s.Key)).ToList(),//s.ToList(),
                CountFields = s.Count(),
                CountSentKeys = llaves.Count()
                // ConcatKeys = String.Join<string>(',', s.ToList().Select(q => q.CodeField)),
                // ConcatValues = String.Join<string>(',', s.ToList().Select(q => q.Value))
            }).Where(t => t.CountFields == t.CountSentKeys).ToList();

            List<int> listIds = new List<int>();
            result.ForEach(v => listIds.Add(v.IdDocument));
            var matchDocuments = await _docBlodStorageContext.Document.Where(u => listIds.Contains(u.IdDocument)).ToListAsync();
            return matchDocuments;
        }

        public async Task<Document> GetById(int idEnt)
        {
            return (await _docBlodStorageContext.Document.FirstOrDefaultAsync(p => p.IdDocument.Equals(idEnt)));
        }

        public async Task<Document> GetOneByCode(string code, string institution)
        {
            return await _docBlodStorageContext.Document.FirstOrDefaultAsync(pp => pp.CodeTypeDocument.Equals(code));


        }

    }
}
