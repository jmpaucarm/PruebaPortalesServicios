using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class TypeFolderRepository : ITypeFolderRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public TypeFolderRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }

        public async Task<int> Add(TypeFolder ent)
        {
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdTypeFolder;
        }

        public async Task<bool> Edit(TypeFolder ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.TypeFolder.AsNoTracking().AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.TypeFolder.AsNoTracking().AnyAsync(p => p.IdTypeFolder.Equals(idEnt)));
        }

        public async Task<List<TypeFolder>> GetAll(string institution, bool active)
        {
            if (active)
                return await _docConfigurationContext.TypeFolder.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();
            return await _docConfigurationContext.TypeFolder.Where(p => p.Institution.Equals(institution)).ToListAsync();
        }

        public async Task<TypeFolder> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.TypeFolder.AsNoTracking()
                .Include(tf => tf.TypeDctoFolder).Include(tf => tf.TypeFolderField)
               
                .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }
    }
}
