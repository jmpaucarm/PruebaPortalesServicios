using System;
using System.Text;
using System.Threading.Tasks;
using Core.General;
using Core.Handlers;
using Core.RabbitMq;
using Newtonsoft.Json;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Services;

namespace OpenDEVCore.Security.Handlers.User
{
    public class UnLockHandler : ICommandHandler<UnLock>
    {
        private readonly IUserService _userService;
        public UnLockHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(UnLock cmnd, ICorrelationContext context)
        {
            await _userService.UnLockAsync(cmnd);
        }
    }
}
