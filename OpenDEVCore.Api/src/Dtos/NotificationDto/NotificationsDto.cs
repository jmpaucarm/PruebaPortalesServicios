using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Dtos
{
    public class NotificationsDto
    {
        public int IdNotification { get; set; }
        public string CodeTemplate { get; set; }
        public string CodeCampaign { get; set; }
        public string Institution { get; set; }
        public int? IdTemplateFormat { get; set; }
        public string Channel { get; set; }
        public string Receptor { get; set; }
        public string Data { get; set; }
        public string Platform { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

    }
}
