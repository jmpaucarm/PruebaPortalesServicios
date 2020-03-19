using OpenDEVCore.Configuration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IOfficeRepository
    {
        Task<List<Office>> GetOffices(int[] ids);
    }
}
