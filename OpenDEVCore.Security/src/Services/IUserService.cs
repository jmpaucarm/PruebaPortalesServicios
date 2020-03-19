using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Types;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Queries;

namespace OpenDEVCore.Security.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(UserGeneral userDto);
        Task<PagedResult<UserDto>> BrowseAllAsync(BrowseAllUsers query);
        Task<List<UserDto>> GetAllAsync();
        Task<bool> FindAsync(UserGeneral query);
        Task<bool> EditAsync(EditUserDto userDto);
        Task<int> AddAsync(AddUserDto userDto);
        Task<UserLoginDto> GetUserProfilesAsync(UserGeneral userDto);
        Task UnLockAsync(UnLock cmnd);
        Task DisconnectAsync(DisconnectUser cmnd);
        Task LockUserAsync(LockUserCommand cmnd);
        Task AddLogSecurityAsync(LogSecurityCommand cmnd);
        Task<List<UserDto>> GetByIds(int[] ids);
        
    }
}
