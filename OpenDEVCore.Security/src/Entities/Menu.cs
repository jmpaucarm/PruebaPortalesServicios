using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            Option = new HashSet<Option>();
        }

        public int IdMenu { get; set; }
        public int? IdMenuOrigin { get; set; }
        public string Channel { get; set; }
        public DateTime? DateSince { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public string Level { get; set; }
        public string Module { get; set; }
        public string RouteLink { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<Option> Option { get; set; }
    }
}
