using System.Data;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.Domain.Dashboard;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DeveloperPortal.Application
{
    public class Dashboard
    {
        public List<DashboardDataModel> GetAllConstructionCases()
        {
            var result = GetAllConstructionCasesData().Result;

            List<DashboardDataModel> resultList = new List<DashboardDataModel>();
            if (result != null && result.Count > 0)
            {
                resultList = result.Select(x => new DashboardDataModel
                {

                    Type = x.Type,
                    CaseId = x.CaseId,
                    SiteCases = x.SiteCases,
                    ComplianceMatrixLink = x.ComplianceMatrixLink,
                    PropertyDetailsLink = x.PropertyDetailsLink,
                    Status = x.Status,
                    AssigneeID = x.AssigneeID,
                    Summary = x.Summary,
                    ProjectName = x.ProjectName,
                    ProjectAddress = x.ProjectAddress,
                    AcHPFileProjectNumber = x.AcHPFileProjectNumber,
                    ProblemProject = x.ProblemProject
                }).ToList();
            }

            return resultList;
        }


        public List<DashboardDataModel> GetAllConstructionCasesForUser()
        {
            List<DashboardDataModel> resultList = new List<DashboardDataModel>();
            try
            {
                var res = GetAllConstructionCasesData();
                var allCases = res.Result;

                if (allCases != null && allCases.Count > 0)
                {
                    Log.Logger.Information("Dashboard:GetAllConstructionCasesForUser : AllCases Count is {AllCasesCount}", allCases.Count());

                    resultList = allCases.Select(x => new DashboardDataModel
                    {
                        Type = x.Type,
                        CaseId = x.CaseId,
                        SiteCases = x.SiteCases,
                        ComplianceMatrixLink = x.ComplianceMatrixLink,
                        PropertyDetailsLink = x.PropertyDetailsLink,
                        Status = x.Status,
                        AssigneeID = x.AssigneeID,
                        Summary = x.Summary,
                        ProjectName = x.ProjectName,
                        ProjectAddress = x.ProjectAddress,
                        AcHPFileProjectNumber = x.AcHPFileProjectNumber,
                        ProblemProject = x.ProblemProject
                    }).ToList();
                }
                return resultList;
            }
            catch (Exception ex)
            {

                Log.Logger.Error("DashboardController:GetMyProjectData : exception is {Message}", ex.Message);
            }
            return resultList;
        }


        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private async Task<List<AllConstructionData>> GetAllConstructionCasesData()
        {
            //AahrdevContext context = new AahrdevContext();
            List<AllConstructionData> result = new List<AllConstructionData>();
            try
            {
                AAHREntitiesHelper context = new AAHREntitiesHelper();
                //List<uspRoGetAllConstructionCasesResult> result = await context.uspRoGetAllConstructionCases();
                result = context.AllConstructionData.FromSql($"EXEC [AAHPCC].[uspRoGetAllConstructionCases]").ToList();
            }
            catch (Exception e)
            {
                //TODO:add logging - Ananth
                Console.WriteLine(e);
            }

            return result;
        }
    }
}
