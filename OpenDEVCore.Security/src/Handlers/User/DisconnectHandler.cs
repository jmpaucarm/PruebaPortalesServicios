using System.Threading.Tasks;
using Core.Handlers;
using Core.RabbitMq;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Handlers.User
{
    public class DisconnectHandler : ICommandHandler<DisconnectUser>
    {
        private readonly IUserService _userService;
        public DisconnectHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(DisconnectUser cmnd, ICorrelationContext context)
        {
            await _userService.DisconnectAsync(cmnd);
        }
    }
}
