using System.Collections.Generic;
using System.Data;
using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.Dashboard;
using Microsoft.Data.SqlClient;
using Serilog;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class DashboardService : IDashboardService
    {

        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IApnpinRepository _apnpinRepository;


        public DashboardService(IStoredProcedureExecutor storedProcedureExecutor, IApnpinRepository apnpinRepository)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _apnpinRepository = apnpinRepository;
        }



        public async Task<List<DashboardDataModel>> GetAllConstructionCases()
        {
            var result = await GetAllConstructionCasesData();

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


        public async Task<List<DashboardDataModel>> GetAllConstructionCasesForUser()
        {
            List<DashboardDataModel> resultList = new List<DashboardDataModel>();
            var res = await GetAllConstructionCasesData();
            var allCases = res;

            if (allCases != null && allCases.Count > 0)
            {
            //Added this log for Serilog testing once testing done We will reomve this line
                Log.Logger.Information("DashboardService:GetAllConstructionCasesForUser : AllCases Count is {AllCasesCount}", allCases.Count());

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


        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private async Task<List<AllConstructionData>> GetAllConstructionCasesData()
        {
            List < AllConstructionData > obj = new List < AllConstructionData >();
            try
            {
                //var data =    await _apnpinRepository.GetAllApnpinsAsync();
                return await _storedProcedureExecutor.ExecuteStoredProcAsync<AllConstructionData>(StoredProcedureNames.SP_uspRoGetAllConstructionCases);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AllConstructionData>();
            }
        }

        Task<List<AllConstructionData>> IDashboardService.GetAllConstructionCasesData()
        {
            return GetAllConstructionCasesData();
        }
    }
}
