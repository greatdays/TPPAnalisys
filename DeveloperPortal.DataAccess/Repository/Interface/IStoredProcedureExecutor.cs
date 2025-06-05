using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IStoredProcedureExecutor
    {
        Task<List<T>> ExecuteStoredProcAsync<T>(string storedProcName, params SqlParameter[] parameters) where T : class, new();
        Task<int> ExecuteNonQueryAsync(string storedProcName, params SqlParameter[] parameters);


    }
}
