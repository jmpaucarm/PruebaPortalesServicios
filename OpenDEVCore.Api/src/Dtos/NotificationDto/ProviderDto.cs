using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Dtos
{
    public class ProviderDto
    {
        public int IdProvider { get; set; }
        public string Institution { get; set; }
        public string Chanel { get; set; }
        public string Code { get; set; }
        public string NameAppMobil { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        
    }
}
