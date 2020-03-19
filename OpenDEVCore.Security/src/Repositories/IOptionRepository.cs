using OpenDEVCore.Security.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Repositories
{
    public interface IOptionRepository
    {
        Task<List<Option>> GetAllAsync();
        Task AddAsync(Option option);
    }
}
