using OpenDEVCore.Security.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Repositories
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<List<Menu>> GetAllScreensAsync();
        Menu Edit(Menu menu);
        Task<Menu> GetByIdAsync(int id);
        Task AddAsync(Menu menu);
    }
}
