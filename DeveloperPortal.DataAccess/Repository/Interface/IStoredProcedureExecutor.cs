using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IStoredProcedureExecutor
    {
        #region AsyncMethods
        Task<List<T>> ExecuteStoredProcAsync<T>(string storedProcName, params SqlParameter[] parameters) where T : class, new();
        Task<int> ExecuteNonQueryAsync(string storedProcName, params SqlParameter[] parameters);
         Task<DataTable> ExecuteStoredProcedureWithDataTableAsync(string storedProcName, List<SqlParameter> parameters);
        #endregion

        #region Non AsyncMethods
        DataTable ExecuteStoreProcedure(string procedureName, List<SqlParameter> parameters);

        Task<T> ExecuteStoredwithDatatableProcAsync<T>(string storedProcName, params SqlParameter[] parameters) where T : class, new();
        #endregion

    }
}
