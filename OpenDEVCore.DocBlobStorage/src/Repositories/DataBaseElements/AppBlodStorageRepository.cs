using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements
{
    public class AppBlodStorageRepository : IAppBlodStorageRepository
    {
        private readonly DocBlodStorageContext _docBlodStorageContext;

        public AppBlodStorageRepository(DocBlodStorageContext docBlodStorageContext)
        {
            _docBlodStorageContext = docBlodStorageContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _docBlodStorageContext.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                _docBlodStorageContext.Reset();
                throw ex;
            }
        }
    }
}
