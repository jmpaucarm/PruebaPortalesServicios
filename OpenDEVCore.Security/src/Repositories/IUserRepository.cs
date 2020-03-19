using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Types;
using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Queries;

namespace OpenDEVCore.Security.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userName);
        Task<bool> FindAsync(string userName);
        User Edit(User user);
        Task AddAsync(User user);
        Task <PagedResult<User>> BrowseAllAsync(BrowseAllUsers id);
        Task<List<User>> GetAllAsync();
        List<MenuOptionDto> GetByUserProfileOffice(int? idUser, int? idProfile, int idOffice);

        Task<List<User>> GetByIds(int[] ids);
    }
}
