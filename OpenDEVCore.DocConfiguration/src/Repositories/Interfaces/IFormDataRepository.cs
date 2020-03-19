using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocConfiguration.Repositories.Interfaces
{
    public interface IFormDataRepository
    {
        DataSet GetFormDataByCode(string databaseCode, string spName, SqlParameter[] spArgs);
    }
}
