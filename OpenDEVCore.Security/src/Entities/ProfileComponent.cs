using System;
using System.Collections.Generic;

namespace OpenDEVCore.Security.Entities
{
    public partial class ProfileComponent
    {
        public int IdProfileComponent { get; set; }
        public int IdProfile { get; set; }
        public int IdComponent { get; set; }

        public virtual Component IdComponentNavigation { get; set; }
        public virtual Profile IdProfileNavigation { get; set; }
    }
}
