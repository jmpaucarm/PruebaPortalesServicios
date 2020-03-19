using Core.Authentication;

namespace OpenDEVCore.Api.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminAuth : JwtAuthAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public AdminAuth() : base("admin")
        {
        }
    }
}