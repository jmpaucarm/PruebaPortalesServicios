using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class TypeBoxRepository : ITypeBoxRepository

    {
        private readonly DocConfigurationContext _docConfigurationContext;

        public TypeBoxRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }

        public async Task<int> Add(TypeBox ent)
        {
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdTypeBox;
        }

        public async Task<bool> Edit(TypeBox ent)
        {
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.TypeBox.AsNoTracking().AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.TypeBox.AsNoTracking().AnyAsync(p => p.IdTypeBox.Equals(idEnt)));

        }

        public async Task<List<TypeBox>> GetAll(string institution, bool active)
        {
            return await _docConfigurationContext.TypeBox.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();
        }

        public async Task<TypeBox> GetByCode(string codeType, string institucion)
        {
            return (await _docConfigurationContext.TypeBox.AsNoTracking().Include(tb => tb.TypeBoxField)
                .FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }

    }
}
