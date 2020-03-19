using System.Threading.Tasks;
using Core.Handlers;
using Core.RabbitMq;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Handlers.User
{
    public class LockUserHandler : ICommandHandler<LockUserCommand>
    {
        private readonly IUserService _userService;
        public LockUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(LockUserCommand cmnd, ICorrelationContext context)
        {
            await _userService.LockUserAsync(cmnd);
        }
    }
}
