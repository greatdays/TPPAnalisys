using System.Data;
using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.Dashboard;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.IDM;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Serilog;
using static DeveloperPortal.DataAccess.Entity.Models.Generated.Case;
using DeveloperPortal.DataAccess.Entity.Models.Generated;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class DashboardService : IDashboardService
    {

        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IApnpinRepository _apnpinRepository;
        public readonly IAccountRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardService(IStoredProcedureExecutor storedProcedureExecutor, IApnpinRepository apnpinRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _apnpinRepository = apnpinRepository;
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
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
        //for getting the userIdentifer id by username 
        public async Task<ContactIdentifier> GetUserContactIdentifierData()
        {
            var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            var contactIdentifierID = await _accountRepository.GetContactIdentifierByUserName(userName);
            return contactIdentifierID;
        }


        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private async Task<List<AllConstructionData>> GetAllConstructionCasesData()
        {
            List<AllConstructionData> obj = new List<AllConstructionData>();
            try
            {
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


        public async Task<List<DashboardDataModel>> GetAllConstructionCasesForUserByUserID()
        {

            var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            if (!string.IsNullOrEmpty(userName))
            {
                var contactIdentifierID = await _accountRepository.GetContactIdentifierByUserName(userName);
                List<DashboardDataModel> resultList = new List<DashboardDataModel>();

                if (contactIdentifierID != null)
                {
                    var res = await GetAllConstructionCasesDataByUser(contactIdentifierID.ContactIdentifierId);
                    var allCases = res;

                    if (allCases != null && allCases.Count > 0)
                    {
                        //Added this log for Serilog testing once testing done We will reomve this line
                        Log.Logger.Information("DashboardService:GetAllConstructionCasesForUser : AllCases Count is {AllCasesCount}", allCases.Count());

                        string achpFileNumbers = string.Join(",", allCases.Select(m => m.AcHPFileProjectNumber));
                        var reviewNotACHPFileNumbers = GetReviewNoteACHPFileNumberByUser(achpFileNumbers);
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
                            ProblemProject = x.ProblemProject,
                            ReviewNoteAcHPFileProjectNumber = reviewNotACHPFileNumbers
                        }).ToList();

                        return resultList;
                    }
                }
            }

            return null;
        }



        private async Task<List<AllConstructionData>> GetAllConstructionCasesDataByUser(int UserID)
        {
            List<AllConstructionData> obj = new List<AllConstructionData>();
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("UserId", UserID)
                };

                var result = await _storedProcedureExecutor.ExecuteStoredProcAsync<AllConstructionData>(
                    StoredProcedureNames.SP_uspRoGetAllConstructionCasesForDevelopmentPortal,
                    parameters
                );
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AllConstructionData>();
            }
        }

        private string GetReviewNoteACHPFileNumberByUser(String ACHPFileNumbers)
        {

            try
            {
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@ACHPfileNumbers", Value = ACHPFileNumbers },
                };
                string fileGroups = string.Empty;

                using (var dataTable = _storedProcedureExecutor.ExecuteStoreProcedure(StoredProcedureNames.SP_uspRoGetReviewNoteACHPFileNumber, sqlParameters))
                {
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        fileGroups = string.Join(",",
                            dataTable.AsEnumerable()
                                     .Select(r => r["FileGroup"].ToString())
                                     .Where(val => !string.IsNullOrWhiteSpace(val)));
                    }
                }
                return fileGroups;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return String.Empty;
            }
        }
    }
}
