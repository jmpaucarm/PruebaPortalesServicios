using System.Threading.Tasks;
using Core.Handlers;
using Core.RabbitMq;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Handlers.User
{
    public class LogSecuritytHandler : ICommandHandler<LogSecurityCommand>
    {
        private readonly IUserService _userService;
        public LogSecuritytHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(LogSecurityCommand cmnd, ICorrelationContext context)
        {
            await _userService.AddLogSecurityAsync(cmnd);
        }
    }
}
