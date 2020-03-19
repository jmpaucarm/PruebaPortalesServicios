using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Dtos
{
    public class CampaignDto
    {
        public int IdCampaign { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Channel { get; set; }
        public int? IdTemplate { get; set; }
        public string Description { get; set; }
        public bool? IsOnLine { get; set; }
        public int? IdFileHeader { get; set; }
        public string NameFile { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public TimeSpan? HourStart { get; set; }
        public TimeSpan? HourEnd { get; set; }
        public string Frequency { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        
    }
}
