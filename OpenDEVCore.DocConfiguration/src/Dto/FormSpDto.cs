using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocConfiguration.Dto
{

    public class FormSpDto
    {
        public string FormCode { get; set; }
        public string Institution { get; set; }
        public string DatabaseCode { get; set; }
        public string SpName { get; set; }

        public List<ParametrosDto> SpArgs;
    }

    public class ParametrosDto
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}

