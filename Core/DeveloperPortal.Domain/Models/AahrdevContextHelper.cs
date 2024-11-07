using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess
{
    internal class AahrdevContextHelper
    {
    }
    public partial class AahrdevContext : DbContext
    {
        public DbSet<uspRoGetAllConstructionCasesResult> uspRoGetAllConstructionCasesResults { get; set; }
        public async Task<List<uspRoGetAllConstructionCasesResult>> uspRoGetAllConstructionCases()
        {
            AahrdevContext context = new AahrdevContext();
            //context.Database.ExecuteSqlInterpolated($"EXEC uspRoGetAllConstructionCases");
            List<uspRoGetAllConstructionCasesResult> result = context.Set<uspRoGetAllConstructionCasesResult>().FromSql($"EXEC uspRoGetAllConstructionCases").ToList<uspRoGetAllConstructionCasesResult>();
            /*return await uspRoGetAllConstructionCasesResult
                .FromSqlRaw($"EXEC MyStoredProcedureName @Param = {parameter}")
                .ToListAsync();*/

            return result;
        }

    }

    public class uspRoGetAllConstructionCasesResult
    {
        public required string Type { get; set; }
        public string? CaseId { get; set; }
        public string? SiteCases { get; set; }
        public string? ComplianceMatrixLink { get; set; }
        public string? PropertyDetailsLink { get; set; }
        public required string Status { get; set; }
        public string? AssigneeID { get; set; }
        public string? Summary { get; set; }
        public required string ProjectName { get; set; }
        public required string ProjectAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public required string ModifiedOn { get; set; }
        public required string AcHPFileProjectNumber { get; set; }
        public required string ProblemProject { get; set; }
    }
}
