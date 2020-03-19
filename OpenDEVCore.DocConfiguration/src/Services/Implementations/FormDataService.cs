using Core.Mvc;
using Newtonsoft.Json;
using OpenDEVCore.DocConfiguration.Dto;
using OpenDEVCore.DocConfiguration.Repositories.Interfaces;
using OpenDEVCore.DocConfiguration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocConfiguration.Services.Implementations
{
    public class FormDataService : BaseService, IFormDataService
    {
        private readonly IFormDataRepository _formDataRepository;
        public FormDataService(IFormDataRepository formDataRepository)
        {
            _formDataRepository = formDataRepository;
        }
        public string GetFormData(string formCode, string institution, string databaseCode, string spName, SqlParameter[] spArgs)
        {
            var dst = _formDataRepository.GetFormDataByCode(databaseCode, spName, spArgs);
            DocumentBusinessDto dto = TransalateFormData(formCode, institution, dst);

            return JsonConvert.SerializeObject(dto);
        }

        private DocumentBusinessDto TransalateFormData(string formCode, string institution, DataSet dst)
        {
            DocumentBusinessDto dto = new DocumentBusinessDto();
            dto.FormCode = formCode;    //"FormCode": "FormLi3",
            dto.Institution = institution; //"Institution":"BDA",

            /*
             "PathDoc":[
                    {"Key": "DNI","Value": "1718325226"},
                    {"Key": "FormCode","Value": "LIQUIDACION"}
                    ]
             */
            if (dst?.Tables.Count > 0 )
            {
                var table1 = dst.Tables[0];
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    string key = table1.Rows[i][0] as string;
                    string value = (table1.Columns.Count > 1) ? table1.Rows[i][1] as string : null; //se busca el dato sólo si existe la columna.
                    dto.PathDoc.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            /*
             "DocParams": [
                      {"Key": "«NUMOPERACION»","Value": "41711300070588"},
                        {"Key": "«NOMBRECLIENTE»","Value": "YESENIA MARICELA TOS  DE LEON"},
                        {"Key": "«OFICINA»","Value": "ID121"},
                        {"Key": "«PRODUCTO»","Value": "UNIFICA CONSUMO"},
                      ]
             */
            if (dst?.Tables.Count > 1)
            {
                var table2 = dst.Tables[1];
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    string key = table2.Rows[i][0] as string;
                    string value = (table2.Columns.Count > 1) ? table2.Rows[i][1] as string : null; //se busca el dato sólo si existe la columna.
                    dto.DocParams.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            //tablas dinámicas
            /*
             "DinamicTable":[
                        {"key":"3","Value":[
                        {"cols":["cell1","cell2"]},
                        {"cols":["cell3","cell4"]},
                        {"cols":["cell5","cell6"]},
                        {"cols":["cell7","cell8"]}
                        ]}
                        ]
             */
            for (int table = 2; table < dst?.Tables.Count; table++) //cada tabla
            {
                var dynamicTable = dst.Tables[table];
                string key = table.ToString();

                List<Rows> listaData = new List<Rows>();
                for (int row = 0; row < dynamicTable.Rows.Count; row++) //cada fila
                {
                    Rows rowDataDto = new Rows();
                    for(int col = 0; col < dynamicTable.Columns.Count; col++)   //cada columna
                    {
                        rowDataDto.cols.Add(dynamicTable.Rows[row][col] as string); //{"cols":["cell1","cell2"]}
                    }

                    listaData.Add(rowDataDto);
                }

                dto.DinamicTable.Add(new KeyValuePair<string, List<Rows>>(key, listaData));   //{"key":"3","Value":[...
            }

            return dto;
        }
    }
}

