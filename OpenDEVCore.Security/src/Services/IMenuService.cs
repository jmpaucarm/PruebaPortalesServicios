using OpenDEVCore.Security.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Services
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetAllAsync();
        Task<bool> EditAsync(MenuDto menuDto);
        Task<List<MenuDto>> GetAllScreensAsync();
        Task<int> AddAsync(MenuDto menuDto);
    }
}
