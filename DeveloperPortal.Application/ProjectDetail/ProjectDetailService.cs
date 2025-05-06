using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.DataAccess.Entity.ViewModel;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DeveloperPortal.Application.ProjectDetail
{
    public class ProjectDetailService : IProjectDetailService
    {
        #region Constructor

        IConfiguration _config;
        
        public ProjectDetailService(IConfiguration configuration)
        {
            _config = configuration;
        }
        
        #endregion
        
        #region Public Methods

        
        public ProjectSummaryModel GetProjectSummary(int caseId, string userName = "")
        {
            var projectSummaryModel = new ProjectSummaryModel();
            try
            {
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@CaseId", Value = caseId },
                };

                using (var caseDetailDt = ExecuteStoreProcedure("[AAHPCC].[uspRoGetConstructionCaseDetail]", sqlParameters))
                {
                    if (caseDetailDt != null && caseDetailDt.Rows.Count > 0)
                    {
                        var i = 0;
                        if (caseDetailDt.Rows.Count > 0)
                        {
                            projectSummaryModel.CaseID = caseId;
                            projectSummaryModel.ServiceRequestId = Convert.ToInt64(caseDetailDt.Rows[i]["ServiceRequestID"]);
                            projectSummaryModel.APN = Convert.ToString(caseDetailDt.Rows[i]["APN"]);
                            projectSummaryModel.CaseType = Convert.ToString(caseDetailDt.Rows[i]["CaseType"]);
                            projectSummaryModel.AcHPFileProjectNumber = Convert.ToString(caseDetailDt.Rows[i]["AcHPFileProjectNumber"]);
                            projectSummaryModel.ProjectName = Convert.ToString(caseDetailDt.Rows[i]["ProjectName"]);
                            projectSummaryModel.ServiceRequestNumber = Convert.ToString(caseDetailDt.Rows[i]["ServiceRequestNumber"]);
                            projectSummaryModel.Status = Convert.ToString(caseDetailDt.Rows[i]["Status"]);
                            projectSummaryModel.HIMSNumber = Convert.ToString(caseDetailDt.Rows[i]["HIMSNumber"]);
                            projectSummaryModel.AcHPFileNumber = Convert.ToString(caseDetailDt.Rows[i]["AcHPFileNumber"]);
                            projectSummaryModel.TypeOfOccupancy = Convert.ToString(caseDetailDt.Rows[i]["TypeOfOccupancy"]);
                            projectSummaryModel.SiteAddress = Convert.ToString(caseDetailDt.Rows[i]["SiteAddress"]);
                            projectSummaryModel.ProjectServiceRequestNumber = Convert.ToString(caseDetailDt.Rows[i]["ProjectServiceRequestNumber"]);
                            projectSummaryModel.AssignedPolicyAnalyst = Convert.ToString(caseDetailDt.Rows[i]["AssignedPolicyAnalyst"]);
                            projectSummaryModel.AssigneeName = Convert.ToString(caseDetailDt.Rows[i]["AssigneeName"]);
                            projectSummaryModel.RefProjectSiteId = Convert.ToInt32(caseDetailDt.Rows[i]["RefProjectSiteID"]);
                            projectSummaryModel.ProblemCase = Convert.ToString(caseDetailDt.Rows[i]["ProblemCase"]);
                            projectSummaryModel.ProjectId = Convert.ToInt32(caseDetailDt.Rows[i]["ProjectId"]);
                            string propertyURL = "";
                            //    AppConfig.GetConfigValue("AAHPURL")
                            //+ "IDM/Authentication/RedirectToOtherApplication?AppKey=PropMgmt&AppURL="
                            //+ AppConfig.GetConfigValue("PCMSPropertyURL")
                            //+ "&TabName=AcHPDetails&parameters=apn=" + caseDetail.APN
                            //+ ",projectSiteID=" + caseDetail.RefProjectSiteID;
                            projectSummaryModel.PropertyURL = propertyURL;



                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log or handle database-related errors
                throw new Exception("Database operation failed.", sqlEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new Exception("An error occurred while fetching the case details.", ex);
            }


            return projectSummaryModel;
        }

        public List<string> GetProjectAssessors(int projectId)
        {
            //List<string> result = null;
            //BaseResponse baseResponse = CreateRequest<BaseResponse>(new { projectId }, $"{baseUrl}Construction/GetProjectAssessors", ActionType.GET);
            //if (HttpStatusCode.OK == baseResponse.ResponseCode)
            //{
            //    result = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(baseResponse.Response));
            //}
            List<string> result = new List<string>() { "test1", "test2" };
            return result;
        }

        /// <summary>
        /// GetUnitMatrixDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        public List<UnitDataModel> GetUnitMatrixDetails(GridRequestModel gridRequestModel)
        {
            var resultList = new List<UnitDataModel>();
            if (gridRequestModel == null)
            {
                return resultList;
            }

            var metrixData = uspGetUnitsForComplianceMetrix(gridRequestModel.CaseId, gridRequestModel.ProjectId);
            if (metrixData != null && metrixData.Count > 0)
            {
                resultList = metrixData.Select(x => new UnitDataModel
                {
                    APNId = x.APNId,
                    SiteAddressID = x.SiteAddressID,
                    ProjectSiteId = x.ProjectSiteId,
                    ProjectId = x.ProjectId,
                    LevelId = x.LevelId,
                    BuildingId = x.BuildingId ?? 0,
                    CaseId = x.CaseId,
                    ServiceRequestId = x.ServiceRequestId,
                    PropSnapshotID = x.PropSnapshotID ?? 0,
                    ACHPNo = x.ACHPNo,
                    UnitID = x.UnitID,
                    UnitNum = x.UnitNum,
                    TotalBedroom = x.TotalBedroom,
                    LutTotalBedroomID = x.LutTotalBedroomID,
                    FloorPlanType = x.FloorPlanType,
                    FloorPlanTypeID = x.FloorPlanTypeID,
                    UnitType = x.UnitType,
                    LutUnitTypeID = x.LutUnitTypeID,
                    ManagersUnit = x.ManagersUnit,
                    IsCSA = x.IsCSA ?? false,
                    IsVCA = x.IsVCA ?? false,
                    AdditionalAccecibility = x.AdditionalAccecibility,
                    IsCompliant = x.IsCompliant ?? false
                }).ToList();
            }
            return resultList;
        }

        /// <summary>
        ///  SetUnitCountDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <returns></returns>
        public TotalUnitDataModel SetUnitCountDetails(List<UnitDataModel> unitModel)
        {
            var UnitCountData = new TotalUnitDataModel();
            UnitCountData.StudioCount = unitModel.Count(x => x.TotalBedroom == "Studio");
            UnitCountData.SROCount = unitModel.Count(x => x.TotalBedroom == "SRO");
            UnitCountData.EfficiencyCount = unitModel.Count(x => x.TotalBedroom == "Efficiency");
            UnitCountData.Bedroom1Count = unitModel.Count(x => x.TotalBedroom == "1");
            UnitCountData.Bedroom2Count = unitModel.Count(x => x.TotalBedroom == "2");
            UnitCountData.Bedroom3Count = unitModel.Count(x => x.TotalBedroom == "3");
            UnitCountData.Bedroom4Count = unitModel.Count(x => x.TotalBedroom == "4");
            UnitCountData.Bedroom5Count = unitModel.Count(x => x.TotalBedroom == "5+");
            UnitCountData.ManagerUnitCount = unitModel.Count(x => x.ManagersUnit == true);
            UnitCountData.TotalCount = UnitCountData.SROCount + UnitCountData.StudioCount + UnitCountData.EfficiencyCount
                + UnitCountData.Bedroom1Count
                + UnitCountData.Bedroom2Count
                + UnitCountData.Bedroom3Count
                + UnitCountData.Bedroom4Count
                + UnitCountData.Bedroom5Count
                + UnitCountData.ManagerUnitCount;
            UnitCountData.UnitDesignatedCSACount = unitModel.Count(x => x.IsCSA == true);
            UnitCountData.UnitDesignatedVCACount = unitModel.Count(x => x.IsVCA == true);
            UnitCountData.TotalMobilityUntCount = unitModel.Count(x => x.UnitType == "Mobility");
            UnitCountData.TotalCommunicationUntCount = unitModel.Count(x => x.UnitType == "Hearing/Vision (H/V)");
            UnitCountData.TotalAdaptableUntCount = unitModel.Count() - unitModel.Count(x => x.UnitType == "Mobility" || x.UnitType == "Hearing/Vision (H/V)");
            UnitCountData.TotalCommunicationCount = Math.Round(Convert.ToDouble(UnitCountData.TotalCount) * 0.04, 2);
            UnitCountData.TotalMobilityUnitsVCACount = UnitCountData.UnitDesignatedCSACount;
            UnitCountData.TotalMobilityUnitsCSACount = UnitCountData.UnitDesignatedVCACount;
            //Percentage caalculation
            UnitCountData.TotalMobilityUnitsPer = 0;
            UnitCountData.TotalCommunicationsPer = 0;
            UnitCountData.TotalMobilityUnitsVCAPer = 0;
            UnitCountData.TotalMobilityUnitsCSAPer = 0;
            if (UnitCountData.TotalCount > 0)
            {
                UnitCountData.TotalMobilityUnitsPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUntCount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalCommunicationsPer = Math.Round(Convert.ToDouble(UnitCountData.TotalCommunicationUntCount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalMobilityUnitsVCAPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUnitsVCACount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
                UnitCountData.TotalMobilityUnitsCSAPer = Math.Round(Convert.ToDouble(UnitCountData.TotalMobilityUnitsCSACount) / Convert.ToDouble(UnitCountData.TotalCount) * 100, 2);
            }
            return UnitCountData;
        }

        /// <summary>
        /// GetSiteInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<SiteInformationModel> GetSiteInformation(int caseId, string userName)
        {
            var siteInformations = new List<SiteInformationModel>();
            var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@CaseId", Value = caseId },
                    new SqlParameter() { ParameterName = "@UserName", Value = userName }
                };
            //AahrdevContext context = new AahrdevContext();
            AAHREntities context = new AAHREntities();
            
            var dd= context.ExecuteStoredProcedureAsync<uspGetUnitsForComplianceMetrix>($"[AAHR].[uspRoGetAllSiteForProject] @CaseId = {caseId} @UserName= {userName}").Result;
            context.Set<List<SiteInformationModel>>().FromSql($"[AAHR].[uspRoGetAllSiteForProject] @CaseId = {caseId} @UserName= {userName}");
            //context.Database.ExecuteSqlRaw("[AAHR].[uspRoGetAllSiteForProject]", sqlParameters);
            /*using (var dataTableAllSites = context.Database.ExecuteStoredProcedure("[AAHR].[uspRoGetAllSiteForProject]", sqlParameters))
            {
                if (dataTableAllSites.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTableAllSites.Rows.Count; i++)
                    {
                        SiteInformationModel siteInformation = new SiteInformationModel();
                        siteInformation.CaseID = Convert.ToInt32(dataTableAllSites.Rows[i]["CaseID"]);
                        siteInformation.RefProjectSiteID = Convert.ToInt32(dataTableAllSites.Rows[i]["RefProjectSiteID"]);
                        siteInformation.ProjectSiteID = Convert.ToInt32(dataTableAllSites.Rows[i]["ProjectSiteID"]);
                        siteInformation.ProjectID = Convert.ToInt32(dataTableAllSites.Rows[i]["ProjectID"]);
                        siteInformation.SiteName = dataTableAllSites.Rows[i]["SiteName"].ToString();
                        siteInformation.FileNumber = dataTableAllSites.Rows[i]["FileNumber"].ToString();
                        siteInformation.SiteAddress = dataTableAllSites.Rows[i]["SiteAddress"].ToString();
                        siteInformation.AssigneeName = dataTableAllSites.Rows[i]["AssigneeName"].ToString();
                        siteInformation.NoOfBuildings = Convert.ToInt32(dataTableAllSites.Rows[i]["NoOfBuildings"]);
                        siteInformation.NoOfUnits = Convert.ToInt32(dataTableAllSites.Rows[i]["NoOfUnits"]);
                        siteInformation.PolicyAnalyst = Convert.ToString(dataTableAllSites.Rows[i]["Policy Analyst"]);
                        siteInformation.SiteCaseStatus = Convert.ToString(dataTableAllSites.Rows[i]["Site Case Status"]);
                        siteInformation.SiteCaseType = Convert.ToString(dataTableAllSites.Rows[i]["Site Case Type"]);
                        siteInformation.Actions = Convert.ToString(dataTableAllSites.Rows[i]["Action"]);
                        siteInformation.DocumentControlViewModelId = Convert.ToInt32(dataTableAllSites.Rows[i]["DocumentControlViewModelId"]);
                        siteInformation.LogsControlViewModelId = Convert.ToInt32(dataTableAllSites.Rows[i]["LogsControlViewModelId"]);
                        siteInformation.ContactControlViewModelId = Convert.ToInt32(dataTableAllSites.Rows[i]["ContactControlViewModelId"]);
                        siteInformations.Add(siteInformation);
                    }
                }
                return siteInformations;
            }*/

            return siteInformations;
        }

        /// <summary>
        /// GetControlViewModelById
        /// </summary>
        /// <param name="controlViewModelId"></param>
        /// <returns></returns>
        public ControlViewModel GetControlViewModelById(int controlViewModelId)
        {   
            AAHREntities context = new AAHREntities();
            ControlViewMaster controlView = context.ControlViewMasters.Include(x => x.ControlMaster).FirstOrDefault(m => m.Id == controlViewModelId);

            ControlViewModel controlViewModel = new ControlViewModel(_config);
            if (controlView != null)
            {
                controlViewModel.Populate(controlView, null);
            }

            return controlViewModel;
        }

        #endregion












        public void GetProjectParticipantsByProjectId(string projectId)
        {
            AAHREntities context = new AAHREntities();
            int projId = 0;
            int.TryParse(projectId, out projId);
            var projectParticipants = context.GetProjectParticipantsByProjectId(projId);
            List<DataAccess.Entity.Models.StoredProcedureModels.ProjectParticipantsModel> proj = projectParticipants.Result;
        }


        #region Private Methods
        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private List<uspGetUnitsForComplianceMetrix> uspGetUnitsForComplianceMetrix(int caseId, int projectId)
        {
            AAHREntities context = new AAHREntities();
            return context.ExecuteStoredProcedureAsync<uspGetUnitsForComplianceMetrix>($"[AAHPCC].[uspGetUnitsForComplianceMetrix] @CaseId = {caseId}, @projectId= {projectId}").Result;
        }


        private DataTable ExecuteStoreProcedure(string procedureName, List<SqlParameter> parameters)
        {
            AAHREntities _context = new AAHREntities();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = procedureName;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }


            }
        }

        #endregion

    }
}
