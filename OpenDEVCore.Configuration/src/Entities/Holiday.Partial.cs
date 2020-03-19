using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Holiday
    {
        public void Add(DateTime holiday) {
            DateHoliday = holiday.Date;
            Year = holiday.Year;
        }
    }
}
