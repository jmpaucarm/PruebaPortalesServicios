using System;

namespace OpenDEVCore.Security.Entities
{
    public partial class UserPassword
    {
        public int IdUserPassword { get; set; }
        public int? IdUser { get; set; }
        public string Password { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

    }
}
