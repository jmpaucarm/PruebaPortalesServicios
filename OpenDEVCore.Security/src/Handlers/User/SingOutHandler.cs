using System.Threading.Tasks;
using Core.Handlers;
using Core.RabbitMq;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Handlers.User
{
    public class SingOutHandler : ICommandHandler<SingOut>
    {
        private readonly IIdentityService _identityService;
        public SingOutHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task HandleAsync(SingOut cmnd, ICorrelationContext context)
        {
            await _identityService.SignOutAsync(cmnd.UserCode);
        }
    }
}
