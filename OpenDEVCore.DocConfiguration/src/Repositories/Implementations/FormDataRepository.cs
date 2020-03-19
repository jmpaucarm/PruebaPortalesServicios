using Core.Data;
using OpenDEVCore.DocConfiguration.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

public class FormDataRepository : IFormDataRepository
{
    private readonly IDataAccess _iDataAccess;
    public FormDataRepository(IDataAccess iDataAccess)
    {
        _iDataAccess = iDataAccess;
    }

    public DataSet GetFormDataByCode(string databaseCode, string spName, SqlParameter[] spArgs)
    {
        return _iDataAccess.ExecuteProcedure(databaseCode, spName, spArgs);
    }
}