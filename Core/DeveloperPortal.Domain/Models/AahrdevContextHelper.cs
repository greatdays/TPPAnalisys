using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.Domain.Models;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;

namespace DeveloperPortal.DataAccess
{
    internal class AahrdevContextHelper
    {
    }
    public partial class AahrdevContext : DbContext
    {
        public DbSet<uspRoGetAllConstructionCasesResult> uspRoGetAllConstructionCasesResults { get; set; }
        public DbSet<uspGetUnitsForComplianceMetrixResult> uspGetUnitsForComplianceMetrixResult { get; set; }
        public async Task<List<uspRoGetAllConstructionCasesResult>> uspRoGetAllConstructionCases()
        {
            AahrdevContext context = new AahrdevContext();
            //context.Database.ExecuteSqlInterpolated($"EXEC uspRoGetAllConstructionCases");
            List<uspRoGetAllConstructionCasesResult> result = context.Set<uspRoGetAllConstructionCasesResult>().FromSql($"EXEC AAHPCC.uspRoGetAllConstructionCases").ToList();
            
            /*return await uspRoGetAllConstructionCasesResult
                .FromSqlRaw($"EXEC MyStoredProcedureName @Param = {parameter}")
                .ToListAsync();*/

            return result;
        }

        public async Task<List<uspGetUnitsForComplianceMetrixResult>> uspGetUnitsForComplianceMetrix(int caseId, int projectId)
        {
            AahrdevContext context = new AahrdevContext();
            //var parameter = new SqlParameter() { ParameterName = "@CaseId", Value = caseId };
            //var CaseId = new SqlParameter() { ParameterName = "@CaseId", Value = caseId };
            //var ProjectId =new SqlParameter() { ParameterName = "@projectID", Value = projectId };
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@CaseId",
                            SqlDbType =  System.Data.SqlDbType.Int,Direction = System.Data.ParameterDirection.Input,
                            Value = caseId
                        },
                        new SqlParameter() {
                            ParameterName = "@projectID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = projectId
                        }};

            List <uspGetUnitsForComplianceMetrixResult> result = context.Set<uspGetUnitsForComplianceMetrixResult>().FromSqlRaw($"EXEC AAHPCC.uspGetUnitsForComplianceMetrix @CaseId, @projectID",param).ToList();
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


    [Keyless]
    public class uspGetUnitsForComplianceMetrixResult
    {   
        public int? UnitID { get; set; }
        public string UnitNum { get; set; }
        public string ACHPNo { get; set; }
        public bool? ManagersUnit { get; set; }
        public string UnitType { get; set; }
        public int? LutUnitTypeID { get; set; }
        public string? FloorPlanType { get; set; }
        public int? FloorPlanTypeID { get; set; }
        
        public string AdditionalAccecibility { get; set; }
        public bool IsCompliant { get; set; }
        public bool IsCSA { get; set; }
        public bool IsVCA { get; set; }
        public int PropSnapshotID { get; set; }
        public int BuildingId { get; set; }
        public int CaseId { get; set; }
        public int? SiteAddressID { get; set; }
        public long? ServiceRequestId { get; set; }
        public int? APNId { get; set; }
        public int? ProjectSiteId { get; set; }
        public int? ProjectId { get; set; }
        
        public int? LevelId { get; set; }
        public int? LutTotalBedroomID { get; set; }
        public string TotalBedroom { get; set; } = string.Empty;
    }

}
