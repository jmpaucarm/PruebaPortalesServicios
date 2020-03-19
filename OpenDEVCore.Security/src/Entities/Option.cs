using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class Option
    {
        public Option()
        {
            Component = new HashSet<Component>();
            ProfileOption = new HashSet<ProfileOption>();
        }

        public int IdOption { get; set; }
        public int? IdMenu { get; set; }
        public string Type { get; set; }
        public string View { get; set; }
        public string Url { get; set; }
        public string DashBoard { get; set; }
        public string Report { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<ProfileOption> ProfileOption { get; set; }
    }
}
