using Microsoft.EntityFrameworkCore;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;

        public BoxRepository(DocBlodStorageContext docBlodStorageContext)
        {
            _docBlodStorageContext = docBlodStorageContext;
        }


        public async Task<int> Add(Box ent)
        {
            await   _docBlodStorageContext.AddAsync(ent);
            await  _docBlodStorageContext.SaveChangesAsync();
            return ent.IdBox;

        }

        public async Task<Box> Edit(Box ent)
        {
            _docBlodStorageContext.Update(ent);
             await _docBlodStorageContext.SaveChangesAsync();
            return ent;

        }

        public async Task<bool> Find(string code, string institution)
        {
            return  await  _docBlodStorageContext.Box.AnyAsync(b=> b.CodeTypeBox.Equals(code)&& b.Institution.Equals(institution));
        }


  
        public async Task<List<Box>> GetAll(string institution, bool active)
        {
            return await   _docBlodStorageContext.Box.Where(b => b.Institution.Equals(institution) && b.IsActive.Equals(active)).ToListAsync();
        }

        public async Task<Box> GetByCode(string codeBox, string institucion)
        {
            return await _docBlodStorageContext.Box.Include("BoxField").FirstOrDefaultAsync(b => b.CodeTypeBox.Equals(codeBox) && b.Institution.Equals(institucion));
        }
    }
}
