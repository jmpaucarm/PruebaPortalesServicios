using Microsoft.EntityFrameworkCore;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;
        private readonly IAppBlodStorageRepository _appBlodStorageRepository;

        public FolderRepository(DocBlodStorageContext docBlodStorageContext, IAppBlodStorageRepository appBlodStorageRepository)
        {
            _docBlodStorageContext = docBlodStorageContext;
            _appBlodStorageRepository = appBlodStorageRepository;

        }

        public async Task<int> Add(Folder entFolder)
        {
            await _docBlodStorageContext.AddAsync(entFolder);
            await _appBlodStorageRepository.SaveAsync();
            return entFolder.IdFolder;
        }

        public async Task<bool> FindById(int id)
        {
            return await _docBlodStorageContext.Folder.AnyAsync(x=>x.IdFolder.Equals(id));

        }

        public async Task<List<Folder>> GetAll(string institution)
        {
            return await _docBlodStorageContext.Folder.Where(y => y.Institution.Equals(institution)).ToListAsync();
        }

        public async Task<Folder> GetById(int id)
        {
            return await _docBlodStorageContext.Folder.FirstOrDefaultAsync(y => y.IdFolder.Equals(id));
        }

        public async Task<Folder> UpdateFolder(Folder entFolder)
        {
            _docBlodStorageContext.Update(entFolder);
            await _docBlodStorageContext.SaveChangesAsync();

            return entFolder;
        }
    }
}
