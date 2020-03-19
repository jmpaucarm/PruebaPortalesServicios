using Core.General;
using System;

namespace OpenDEVCore.Security.Entities
{
    public partial class LogSecurity : ICoreEF
    {
        public int IdLogSecurity { get; set; }
        public string Event { get; set; }
        public DateTime? DateRegistry { get; set; }
        public int? IdOffice { get; set; }
        public string Machine { get; set; }
        public int? IdUser { get; set; }
        public string UserCode { get; set; }
        public int? Attempts { get; set; }
        public int? IdProfile { get; set; }
        public string Observation { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }

        protected LogSecurity() { }
        public LogSecurity(int idUser, string userCode, string codecatalogue, string description)
        {

            Event = codecatalogue;
            DateRegistry = DateTime.Now;
            IdUser = idUser;
            UserCode = userCode;
            Attempts = 0;
            Observation = description;
        }
    }
}
