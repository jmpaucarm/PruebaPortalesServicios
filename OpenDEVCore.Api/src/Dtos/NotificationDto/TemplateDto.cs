using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Dtos
{
    public class TemplateDto
    {
        public int IdTemplate { get; set; }
        public int? IdProvider { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Chanel { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }


    }
}
