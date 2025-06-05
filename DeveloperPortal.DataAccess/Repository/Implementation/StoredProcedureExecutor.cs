using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly AAHREntitiesHelper _contextData;

        public StoredProcedureExecutor(AAHREntitiesHelper _contextData)
        {
            this._contextData = _contextData;
        }

        public async Task<List<T>> ExecuteStoredProcAsync<T>(string storedProcName, params SqlParameter[] parameters) where T : class, new()
        {
            var sql = BuildSqlCommand(storedProcName, parameters);
            return await _contextData.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<int> ExecuteNonQueryAsync(string storedProcName, params SqlParameter[] parameters)
        {
            var sql = BuildSqlCommand(storedProcName, parameters);
            return await _contextData.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        private static string BuildSqlCommand(string storedProcName, SqlParameter[] parameters)
        {
            var paramNames = parameters != null && parameters.Length > 0
                ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName}"))
                : string.Empty;

            return $"EXEC {storedProcName} {paramNames}";
        }
    }
}
