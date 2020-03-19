using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories.Implementations
{
    public class FolderFieldRepository : IFolderFieldRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;
        private readonly IAppBlodStorageRepository _appBlodStorageRepository;

        public FolderFieldRepository(DocBlodStorageContext docBlodStorageContext, IAppBlodStorageRepository appBlodStorageRepository)
        {
            _docBlodStorageContext = docBlodStorageContext;
            _appBlodStorageRepository = appBlodStorageRepository;
        }

        public async Task<int> Add(FolderField entFolderField)
        {
            await _docBlodStorageContext.AddAsync(entFolderField);
            await _appBlodStorageRepository.SaveAsync();
            return entFolderField.IdFolderField;
        }

    }
}
