using Core.General;
using Core.Messages;

namespace OpenDEVCore.Security.Dto
{
    public class UserGeneral : CoreDto
    {
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Station { get; set; }
        public string NewPassword { get; set; }
        public int Profile { get; set; }
        public string ProfileCode { get; set; }
        public int Office { get; set; }
    }
}
