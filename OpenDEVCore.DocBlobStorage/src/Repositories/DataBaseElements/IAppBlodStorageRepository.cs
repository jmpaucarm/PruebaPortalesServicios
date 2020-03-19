using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements
{
    public interface IAppBlodStorageRepository 
    {
        Task<bool> SaveAsync();//CONTROL DE LOS CAMBIOS EN LA BDD

    }
}
