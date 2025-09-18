using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly AAHREntitiesHelper _contextData;

        public StoredProcedureExecutor(AAHREntitiesHelper contextData)
        {
            _contextData = contextData;
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

        public DataTable ExecuteStoreProcedure(string procedureName, List<SqlParameter> parameters)
        {

            using (var command = _contextData.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = procedureName;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                _contextData.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }


            }
        }

        public async Task<DataTable> ExecuteStoredProcedureWithDataTableAsync(string storedProcName, List<SqlParameter> parameters)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_contextData.Database.GetConnectionString()))
            {
                using (var command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        await connection.OpenAsync();
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }


        private static string BuildSqlCommand(string storedProcName, SqlParameter[] parameters)
        {
            var paramNames = parameters != null && parameters.Length > 0
                ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName}"))
                : string.Empty;

            return $"EXEC {storedProcName} {paramNames}";
        }

        public async Task<T> ExecuteStoredwithDatatableProcAsync<T>(string storedProcName, params SqlParameter[] parameters) where T : class, new()
        {
            var sql = BuildSqlCommand(storedProcName, parameters);

            // Execute the stored procedure on the server and load results into memory
            return _contextData.Set<T>().FromSqlRaw(sql, parameters).AsEnumerable().FirstOrDefault();
        }
    }
}
