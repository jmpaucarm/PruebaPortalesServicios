using Core.Handlers;
using Core.Types;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Queries;
using OpenDEVCore.Security.Services;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Handlers.User
{
    public class BrowseAllUsersHandler : IQueryHandler<BrowseAllUsers, PagedResult<UserDto>>
    {
        private readonly IUserService _userService;

        public BrowseAllUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PagedResult<UserDto>> HandleAsync(BrowseAllUsers query)
        {
            return await _userService.BrowseAllAsync(query);
        }
    }
}
