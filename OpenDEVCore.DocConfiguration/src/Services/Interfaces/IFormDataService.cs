using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocConfiguration.Services.Interfaces
{
    public interface IFormDataService
    {
        string GetFormData(string formCode, string institution, string databaseCode, string spName, SqlParameter[] spArgs);
    }
}
