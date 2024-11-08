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
            List<uspRoGetAllConstructionCasesResult> result = context.Set<uspRoGetAllConstructionCasesResult>().FromSql($"EXEC AAHPCC.uspRoGetAllConstructionCases").ToList<uspRoGetAllConstructionCasesResult>();
            
            /*return await uspRoGetAllConstructionCasesResult
                .FromSqlRaw($"EXEC MyStoredProcedureName @Param = {parameter}")
                .ToListAsync();*/

            return result;
        }

    }

    [Keyless]
    public class uspRoGetAllConstructionCasesResult
    {   
        public string? Type { get; set; }
        public string? CaseId { get; set; }
        public string? SiteCases { get; set; }
        public string? ComplianceMatrixLink { get; set; }
        public string? PropertyDetailsLink { get; set; }
        public string? Status { get; set; }
        public string? AssigneeID { get; set; }
        public string? Summary { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectAddress { get; set; }
        public string? CreatedOn { get; set; }
        public string? ModifiedOn { get; set; }
        public string? AcHPFileProjectNumber { get; set; }
        public string? ProblemProject { get; set; }
    }
}
