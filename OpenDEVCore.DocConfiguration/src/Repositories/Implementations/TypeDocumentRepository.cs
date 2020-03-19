using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public TypeDocumentRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }

        public async Task<int> Add(TypeDocument ent)
        {
            await _docConfigurationContext.AddAsync(ent);

            _docConfigurationContext.SaveChanges();
            return ent.IdTypeDocument;
        }

        public async Task<bool> Edit(TypeDocument ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {

            return (await _docConfigurationContext.TypeDocument.AsNoTracking().AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }


        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.TypeDocument.AsNoTracking().AnyAsync(p => p.IdTypeDocument.Equals(idEnt)));
        }



        public async Task<List<TypeDocument>> GetAll(string institution, bool active)
        {
            if (active)
                return await _docConfigurationContext.TypeDocument.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).Include(td => td.TypeDctoField).ToListAsync();
            return await _docConfigurationContext.TypeDocument.Where(p => p.Institution.Equals(institution)).Include(td => td.TypeDctoField).Include(td => td.FormVersion).ToListAsync();

        }

        public async Task<List<TypeDocument>> GetAllForm(string institution, bool isForm)
        {
            return await _docConfigurationContext.TypeDocument.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsForm == isForm).Include(td => td.FormVersion).ToListAsync();
        }

        public async Task<TypeDocument> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.TypeDocument.AsNoTracking()
                .Include(td => td.Area)
                .Include(td => td.AreaOcr)
                .Include(td => td.TypeDctoField)
                .Include(td => td.TypeDctoFolder)
                .Include(td => td.FormVersion)
                .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }

        public Task<List<TypeDocument>> GetConfigurations(List<string> codigos, string institucion)
        {
            return _docConfigurationContext.TypeDocument.Where(p => p.Institution.Equals(institucion) && codigos.Contains(p.Code)).Include(td => td.FormVersion).ToListAsync();
        }
    }
}

