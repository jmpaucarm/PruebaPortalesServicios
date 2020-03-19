using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public class TypeImageRepository : ITypeImageRepository
    {
        private readonly DocConfigurationContext _docConfigurationContext;
        public TypeImageRepository(DocConfigurationContext docConfigurationContext)
        {
            _docConfigurationContext = docConfigurationContext;
        }

        public async Task<int> Add(TypeImage ent)
        {
            //Refactorizar todo el tema que tenga una accion de commit a la BDD para 
            //guia revisar en seguridad de como se esta manejando este tema  
            await _docConfigurationContext.AddAsync(ent);
            _docConfigurationContext.SaveChanges();
            return ent.IdTypeImage;
        }

        public async Task<bool> Edit(TypeImage ent)
        {
            //Refactorizar todo el tema que tenga una accion de commit a la BDD para 
            //guia revisar en seguridad de como se esta manejando este tema  
            _docConfigurationContext.Update(ent);
            await _docConfigurationContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return (await _docConfigurationContext.TypeImage.AsNoTracking().AnyAsync(p => p.Code.Equals(code) && p.Institution.Equals(institution)));
        }

        public async Task<bool> FindById(int idEnt)
        {
            return (await _docConfigurationContext.TypeImage.AsNoTracking().AnyAsync(p => p.IdTypeImage.Equals(idEnt)));

        }

        public async Task<List<TypeImage>> GetAll(string institution, bool active)
        {
            if (active)
                return await _docConfigurationContext.TypeImage.AsNoTracking().Where(p => p.Institution.Equals(institution) && p.IsActive.Equals(active)).ToListAsync();
            return await _docConfigurationContext.TypeImage.Where(p => p.Institution.Equals(institution)).ToListAsync();

        }

        public async Task<TypeImage> GetByCode(string codeType, string institucion)
        {

            return (await _docConfigurationContext.TypeImage.AsNoTracking().FirstOrDefaultAsync(p => p.Code.Equals(codeType) && p.Institution.Equals(institucion)));
        }
    }
}
