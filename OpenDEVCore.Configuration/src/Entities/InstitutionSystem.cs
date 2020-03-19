using System;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class InstitutionSystem
    {
        public int IdInstitutionSystem { get; set; }
        public int? IdInstitution { get; set; }
        public string System { get; set; }

        public virtual Institution IdInstitutionNavigation { get; set; }
    }
}
