using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocConfiguration.Dto
{
/*
 {
    "FormCode": "FormLi3",
    "Institution":"BDA",
    "PathDoc":[
    {"Key": "DNI","Value": "1718325226"},
    {"Key": "FormCode","Value": "LIQUIDACION"}
    ], 
    "DocParams": [
      {"Key": "«NUMOPERACION»","Value": "41711300070588"},
        {"Key": "«NOMBRECLIENTE»","Value": "YESENIA MARICELA TOS  DE LEON"},
        {"Key": "«OFICINA»","Value": "ID121"},
        {"Key": "«PRODUCTO»","Value": "UNIFICA CONSUMO"},
      ],
    
    "DinamicTable":[
    {"key":"3","Value":[
    {"cols":["cell1","cell2"]},
    {"cols":["cell3","cell4"]},
    {"cols":["cell5","cell6"]},
    {"cols":["cell7","cell8"]}
    ]}
    ]
}
 * */

    public class DocumentBusinessDto
    {
        public DocumentBusinessDto()
        {
            this.PathDoc = new List<KeyValuePair<string, string>>();
            this.DocParams = new List<KeyValuePair<string, string>>();
            this.DinamicTable = new List<KeyValuePair<string, List<Rows>>>();
        }
        public string FormCode { get; set; }
        public string Institution { get; set; }
        public int FormVersionCodeTMP { get; set; }
        public List<KeyValuePair<string, string>> DocParams { get; set; }
        public string IdentificationNumber { get; set; }
        public string BusinessReference { get; set; }
        public string ExternalReference { get; set; }
        public List<KeyValuePair<string, string>> PathDoc { get; set; }
        public List<KeyValuePair<string, List<Rows>>> DinamicTable { get; set; }
    }

    public class Rows
    {
        public Rows()
        {
            cols = new List<string>();
        }
        public List<string> cols { get; set; }
    }
}
