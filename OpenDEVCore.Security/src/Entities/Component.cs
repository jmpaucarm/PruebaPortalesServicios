using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class Component
    {
        public Component()
        {
            ProfileComponent = new HashSet<ProfileComponent>();
        }

        public int IdComponent { get; set; }
        public int? IdOption { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
        public bool Hidden { get; set; }
        public string ComponentName { get; set; }

        public virtual Option IdOptionNavigation { get; set; }
        public virtual ICollection<ProfileComponent> ProfileComponent { get; set; }
    }
}
