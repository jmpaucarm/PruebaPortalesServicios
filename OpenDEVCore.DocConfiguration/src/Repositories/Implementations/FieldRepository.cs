
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public FieldRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }
        public async Task<int> Add(Field ent)
        {
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdField;
        }

        public async Task<bool> Edit(Field ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.Field.AsNoTracking().AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.Field.AsNoTracking().AnyAsync(p => p.IdField.Equals(idEnt)));
        }

     

        public async Task<List<Field>> GetAll(string institution, bool active)
        {
            if (active)
                return await _docConfigurationContext.Field.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();
            return await _docConfigurationContext.Field.Where(p => p.Institution.Equals(institution)).ToListAsync();
        }

        public async Task<Field> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.Field.AsNoTracking().Include(f=> f.TypeBoxField).Include(f => f.TypeDctoField).Include(f => f.TypeFolderField)
                .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }

        public async Task<Field> GetCodeByID(int id)
        {
            return (await _docConfigurationContext.Field//.AsNoTracking().Include(f => f.TypeBoxField).Include(f => f.TypeDctoField).Include(f => f.TypeFolderField)
                .FirstOrDefaultAsync(f=> f.IdField.Equals(id)));
        }
    }
}
