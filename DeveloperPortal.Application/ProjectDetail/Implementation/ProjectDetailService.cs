using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.DataAccess.Entity.ViewModel;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace DeveloperPortal.Application.ProjectDetail
{
    public class ProjectDetailService : IProjectDetailService
    {
        #region Constructor

        private IConfiguration _config;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IProjectDetailRepository _projectDetailRepository;

        /// <summary>
        /// ProjectDetailService
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="storedProcedureExecutor"></param>
        /// <param name="projectDetailRepository"></param>
        public ProjectDetailService(IConfiguration configuration, IStoredProcedureExecutor storedProcedureExecutor,
            IProjectDetailRepository projectDetailRepository)
        {
            _config = configuration;
            _storedProcedureExecutor = storedProcedureExecutor;
            _projectDetailRepository = projectDetailRepository;
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
                using (var caseDetailDt = _storedProcedureExecutor.ExecuteStoreProcedure("[AAHPCC].[uspRoGetConstructionCaseDetail]", sqlParameters))
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

        public List<string> GetReviewNote(int caseId)
        {
            List<string> reviewNotes = new List<string>();
            try
            {
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@CaseId", Value = caseId },
                };
                using (var dataTable = _storedProcedureExecutor.ExecuteStoreProcedure(StoredProcedureNames.SP_uspRoGetReviewNoteForProject, sqlParameters))
                {
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        reviewNotes = dataTable.AsEnumerable()
                                .Select(row => row[0]?.ToString())
                                .Where(val => !string.IsNullOrEmpty(val))
                                .ToList();
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
            return reviewNotes;
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
            var sqlParameters = new List<SqlParameter>
            {
                    new SqlParameter() { ParameterName = "@CaseId", Value = gridRequestModel.CaseId },
                    new SqlParameter() { ParameterName = "@projectId", Value = gridRequestModel.ProjectId }
                };

            var data = _storedProcedureExecutor.ExecuteStoreProcedure("AAHPCC.uspGetUnitsForComplianceMetrix", sqlParameters);
            var metrixData = data.ConvertDataTable<uspGetUnitsForComplianceMetrix>();
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
        /// UpdateUnitDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUnitDetails(UnitDataModel unitModel, string userName)
        {
            var unitAtt = await _projectDetailRepository.UnitAttribute(unitModel.PropSnapshotID);
            if (unitAtt != null)
            {
                Unit? unit = await _projectDetailRepository.Unit(unitModel.PropSnapshotID);
                if (unit != null)
                {
                    unit.UnitNum = unitModel.UnitNum;
                }
                unitAtt.IsCsa = unitModel.IsCSA;
                unitAtt.IsVca = unitModel.IsVCA;
                unitAtt.LutTotalBedroomId = unitModel.LutTotalBedroomID;
                unitAtt.LutUnitTypeId = unitModel.LutUnitTypeID;
                unitAtt.FloorPlanType = unitModel.FloorPlanType;
                unitAtt.FloorPlanTypeId = unitModel.FloorPlanTypeID;
                unitAtt.AccessibleFeatureType = unitModel.AdditionalAccecibility;
                unitAtt.IsManagersUnit = unitModel.ManagersUnit.HasValue ? unitModel.ManagersUnit.HasValue : false;
                unitAtt.IsCompliant = unitModel.IsCompliant;
                await _projectDetailRepository.SaveChangesWithAuditAsync(userName);
                var policyComplianceDetail = await _projectDetailRepository.PolicyComplianceDetail(unitModel.ServiceRequestId);
                if (policyComplianceDetail == null && unitModel.IsCompliant)
                {
                    PolicyComplianceDetail newPolicyComplianceDetail = new PolicyComplianceDetail
                    {
                        ServiceRequestId = unitModel.ServiceRequestId,
                        CaseId = Convert.ToInt32(unitModel.CaseId),
                        IsCompliant = unitModel.IsCompliant
                    };
                    await _projectDetailRepository.AddPolicyComplianceDetail(newPolicyComplianceDetail, userName);
                }
                else if (policyComplianceDetail != null && policyComplianceDetail.IsCompliant != unitModel.IsCompliant)
                {
                    policyComplianceDetail.IsCompliant = unitModel.IsCompliant;
                    await _projectDetailRepository.UpdatePolicyComplianceDetail(policyComplianceDetail, userName);

                }
                //Added by Dipti
                //Jira Ticket - ACHP Improvement / Task ACHP-17 -> calling Property Api to update PCMS Unit table 
                //Task.Factory.StartNew(() =>
                //{
                //    ComCon.PropertySnapshot.ServiceClient.CommonServiceClient.UpdatePnCUnitToPCMSUnitAsync(unit.UnitID);
                //});
                //end
            }
            return true;
        }

        /// <summary>
        /// AddUnitDetail
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        public async Task<bool> AddUnitDetail(UnitDataModel model, string userName)
        {
            Unit unit = new Unit();
            await SetBuildingReferenceData(model);
            PropSnapshot propSnapshot = new PropSnapshot();
            if (model.UnitID == 0)
            {
                unit.Apnid = model.APNId;
                unit.SiteAddressId = model.SiteAddressID;
                unit.ProjectSiteId = model.ProjectSiteId;
                unit.ProjectId = model.ProjectId;
                unit.BuildingId = model.BuildingId;
                unit.UnitNum = model.UnitNum;
                unit.ProjectSiteId = model.ProjectSiteId;
                unit.LevelId = model.LevelId;
                unit.Status = "X";
                unit.Source = "Construction";
                unit.Attributes = "{\"Status\":\"V\"}";
                unit.IsDeleted = false;
                await _projectDetailRepository.AddUnit(unit, userName);

                //Added by Dipti
                //Jira Ticket - ACHP Improvement / Task ACHP-17 -> calling Property Api to update PCMS Unit table 
                //Task.Factory.StartNew(() =>
                //{
                //    ComCon.PropertySnapshot.ServiceClient.CommonServiceClient.UpdatePnCUnitToPCMSUnitAsync(unit.UnitID);
                //});
                //end

                propSnapshot.UnitId = unit.UnitId;
                propSnapshot.IdentifierType = "Unit";
                propSnapshot.Status = "X";
                propSnapshot.ProjectId = unit.ProjectId;
                propSnapshot.ProjectSiteId = unit.ProjectSiteId;
                propSnapshot.SiteAddressId = unit.SiteAddressId;
                propSnapshot.StructureId = unit.BuildingId;
                propSnapshot.Apnid = unit.Apnid;
                propSnapshot.CreatedOn = DateTime.Now;

                #region Create New UnitAttribute For  UnitModel
                var newUnitAttribute = new UnitAttribute()
                {
                    UnitAttributeId = 0,
                    PropSnapshotId = propSnapshot.PropSnapshotId,
                    SquareFeet = 0,
                    IsVca = model.IsVCA,
                    IsCompliant=model.IsCompliant,
                    IsCsa = model.IsCSA,
                    IsManagersUnit = model.ManagersUnit,
                    LutTotalBedroomId = model.LutTotalBedroomID,
                    FloorPlanTypeId = model.FloorPlanTypeID,
                    FloorPlanType = model.FloorPlanType,
                    LutUnitTypeId = model.LutUnitTypeID,
                    AccessibleFeatureType = model.AdditionalAccecibility,
                    CreatedOn = DateTime.Now
                };

                propSnapshot.UnitAttributePropSnapshot=newUnitAttribute;

                #endregion
                await _projectDetailRepository.AddPropSnapshots(model.CaseId, propSnapshot, userName);
                return true;

            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propId"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUnit(int propId, string username)
        {
            return await _projectDetailRepository.DeleteUnit(propId, username);
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
            using (var dataTableAllSites = ExecuteStoreProcedure("[AAHR].[uspRoGetAllSiteForProject]", sqlParameters))
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
            }
        }

        /// <summary>
        /// GetControlViewModelById
        /// </summary>
        /// <param name="controlViewModelId"></param>
        /// <returns></returns>
        public ControlViewModel GetControlViewModelById(int controlViewModelId)
        {
            // ControlViewMaster controlView = _context.ControlViewMasters.FirstOrDefault(m => m.Id == controlViewModelId);
            ControlViewModel controlViewModel = new ControlViewModel(_config);
            //if (controlView != null)
            //{
            //    controlViewModel.Populate(controlView, null);
            //}

            return controlViewModel;
        }

        #endregion

        /// <summary>
        /// Get Project actions by Case Id and logged in user roles
        /// </summary>
        /// <param name="caseId">Case Id</param>
        /// <param name="roles">Comma Separated Role Names</param>
        /// <returns>List of action names</returns>
        public string GetProjectActionsByCaseId(int caseId, string roles)
        {
            string action = string.Empty;
            var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@caseId", Value = caseId },
                    new SqlParameter() { ParameterName = "@roles", Value = roles }
                };
            using (var dataTableAllSites = ExecuteStoreProcedure("[AAHR].[uspRoGetProjectActions]", sqlParameters))
            {
                if (dataTableAllSites.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTableAllSites.Rows)
                    {
                        action = item[0].ToString();
                        action = action.Replace("<ActionNames>", string.Empty);
                        action = action.Replace("</ActionNames>", string.Empty);
                    }
                }
            }

            return action;
        }

        /// <summary>
        /// GetBuildingInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public List<BuildingParkingInformationModal> GetBuildingInformation(int caseId)
        {
            List<BuildingParkingInformationModal> buildingInformation = new List<BuildingParkingInformationModal>();
            List<SelectListItem> LutApplicableAccessibilityStandard = GetApplicableAccessibilityStandard();

            var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@CaseId", Value = caseId }
                };
            var dt = ExecuteStoreProcedure(StoredProcedureNames.SP_uspRoGetBuildingParkingInfo, sqlParameters);


            buildingInformation = dt.ConvertDataTable<BuildingParkingInformationModal>();
            foreach (var buildingInfo in buildingInformation)
            {
                buildingInfo.LutApplicableAccessibilityList = LutApplicableAccessibilityStandard;
                if (!string.IsNullOrEmpty(buildingInfo.LutApplicableAccessibilityStandardId))
                {

                    var listId = buildingInfo.LutApplicableAccessibilityStandardId.Split(',');
                    buildingInfo.ApplicableCodes = string.Join(", ", LutApplicableAccessibilityStandard.Where(x => listId.Contains(x.Value)).Select(y => y.Text).ToList());
                }
            }

            return buildingInformation;
        }

        /// <summary>
        /// GetPropSnapshotDetails
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<BuildingModel> GetPropSnapshotDetails(int projectSiteId)
        {
            BuildingModel model = new BuildingModel();
            var propSSProjectSite = await _projectDetailRepository.PropSnapshotByProject(projectSiteId);
            if (propSSProjectSite != null)
            {
                model.siteAddressId = (int)propSSProjectSite.SiteAddressId;
                model.ProjectSiteId = propSSProjectSite.ProjectSiteId;
                model.ProjectId = (int)propSSProjectSite.ProjectId;
                model.APNId = (int)propSSProjectSite.Apnid;
            }
            return model;
        }

        /// <summary>
        /// GetLADBSPermitDetails
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="permitNumber"></param>
        /// <returns></returns>
        public async Task<PcisPermitDetail> GetLADBSPermitDetails(int propSnapshotId, string permitNumber)
        {
            var structureAttributes = await _projectDetailRepository.StructureAttribute(propSnapshotId);
            if (structureAttributes != null)
            {
                string LADBSjson = structureAttributes.Ladbsjson ?? "";

                List<PcisPermitDetail> allPermits = JsonConvert.DeserializeObject<List<PcisPermitDetail>>(LADBSjson);

                if (allPermits != null)
                {
                    PcisPermitDetail Permit = allPermits.FirstOrDefault(m => m.PermitNumber == permitNumber && m.Department == "HPP");
                    return Permit;
                }
            }

            return null;
        }
        /// <summary>
        /// GetAllPermitNumbers
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetAllPermitNumbers(int propSnapshotId)
        {
            try
            {
                var structureAttributes = await _projectDetailRepository.StructureAttribute(propSnapshotId);
                if (structureAttributes != null)
                {
                    return new List<string>()
                    {
                        structureAttributes.FirstBuldingPermitNumber,
                        structureAttributes.MostRecentBuldingPermitNumber,
                        structureAttributes.CurrentBuldingPermitNumber,
                        Convert.ToString(structureAttributes.BuildingPermitNumber),
                        structureAttributes.HistoricBuildingPermitNumber,
                        structureAttributes.DbsretrofitBuildingPermitNumber
                    };
                }

                return new List<string>();


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// GetLADBSDataByPermitNumber
        /// </summary>
        /// <param name="PermitNumber"></param>
        /// <param name="Department"></param>
        /// <returns></returns>
        public async Task<PcisPermitDetail> GetLADBSDataByPermitNumber(string PermitNumber, string Department)
        {

            ServiceClient.ServiceClient serviceClient = new ServiceClient.ServiceClient(_config);
            string LADBS_API_URL = _config["AppSettings:LADBSAPIURL"];
            PermitNumber = PermitNumber.Replace("-", "").Trim();
            Department = Department.Replace("(", "").Replace(")", "");
            string requestUrl = string.Format(LADBS_API_URL, PermitNumber, Department);
            PcisPermitDetail result = null;
            try
            {
                PcisPermitDetail baseResponse = serviceClient.CreateRequest<PcisPermitDetail>(null, requestUrl, ServiceClient.ServiceClient.ActionType.GET);
                if (baseResponse != null)
                {
                    result = new PcisPermitDetail();
                    result = baseResponse;
                    result.Department = Department;
                }

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        /// <summary>
        /// GetLADBSPermitNumberList
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetLADBSPermitNumberList(int propSnapshotId)
        {
            try
            {
                var structureAttributes = await _projectDetailRepository.StructureAttribute(propSnapshotId);
                if (structureAttributes != null)
                {
                    string LADBSjson = structureAttributes.Ladbsjson ?? "";
                    List<PcisPermitDetail> pcisPermitDetails = JsonConvert.DeserializeObject<List<PcisPermitDetail>>(LADBSjson);
                    if (pcisPermitDetails != null)
                        return pcisPermitDetails.Select(m => m.PermitNumber + " (" + m.Department + ")").ToList();

                }

                return new List<string>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// SaveLADBSData
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="models"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<string> SaveLADBSData(int propSnapshotId, List<PcisPermitDetail> models, string userName)
        {
            try
            {
                var structureAttribute = await _projectDetailRepository.StructureAttribute(propSnapshotId);
                List<PcisPermitDetail> permits = new List<PcisPermitDetail>();
                if (structureAttribute == null)
                {
                    return "";
                }
                if (structureAttribute.Ladbsjson != null)
                    permits = JsonConvert.DeserializeObject<List<PcisPermitDetail>>(structureAttribute.Ladbsjson);

                foreach (var model in models)
                {
                    // Add if doesn't exist
                    if (!permits.Any(m => m.PermitNumber == model.PermitNumber && m.Department == model.Department))
                    {
                        permits.Add(model);
                    }
                    // Remove and Add if it does (Refresh)
                    else if (permits.Any(m => m.PermitNumber == model.PermitNumber && m.Department == model.Department) && !model.Delete)
                    {
                        permits.RemoveAll(m => m.PermitNumber == model.PermitNumber && m.Department == model.Department);
                        permits.Add(model);
                    }
                    else if (model.Delete)
                    {
                        permits.RemoveAll(m => m.PermitNumber == model.PermitNumber && m.Department == model.Department);
                    }
                }

                structureAttribute.Ladbsjson = JsonConvert.SerializeObject(permits);
                structureAttribute.ModifiedOn = DateTime.Now;
                structureAttribute.ModifiedBy = userName;
                await _projectDetailRepository.UpdateStructureAttributesAsync(structureAttribute);


                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        ///Get LutTotalBedrooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetLutTotalBedrooms()
        {
            var lutTotalBedroomList = await _projectDetailRepository.LutTotalBedrooms();
            var lutTotalBedrooms = lutTotalBedroomList.Select(a => new SelectListItem
            {
                Value = a.LutTotalBedroomsId.ToString(),
                Text = a.Description
            }).ToList();

            foreach (var item in lutTotalBedrooms)
            {
                switch (item.Text)
                {
                    case "1":
                        item.Text = "1 Bedroom";
                        break;
                    case "2":
                        item.Text = "2 Bedroom";
                        break;
                    case "3":
                        item.Text = "3 Bedroom";
                        break;
                    case "4":
                        item.Text = "4 Bedroom";
                        break;
                    case "5+":
                        item.Text = "5 Bedroom";
                        break;
                    default:
                        break;
                }
            }
            return lutTotalBedrooms;
        }
        /// <summary>
        /// Ge tLutUnitType
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetLutUnitType()
        {
            var lutUnitTypesList = await _projectDetailRepository.LutUnitTypes();
            var lutUnitTypes = lutUnitTypesList.Select(a => new SelectListItem
            {
                Value = a.LutUnitTypeId.ToString(),
                Text = a.UnitType
            }).ToList();
            lutUnitTypes.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Select"
            });
            return lutUnitTypes;
        }

        public void GetProjectParticipantsByProjectId(string projectId)
        {
            int projId = 0;
            //int.TryParse(projectId, out projId);
            //var projectParticipants = _context.GetProjectParticipantsByProjectId(projId);
            //List<DataAccess.Entity.Models.StoredProcedureModels.ProjectParticipantsModel> proj = projectParticipants.Result;
        }



        /// <summary>
        /// GetApplicableAccessibilityStandard
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetApplicableAccessibilityStandard()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Section 504" },
                new SelectListItem { Value = "2", Text = "2010 ADA w/ 11 HUD Exceptions" },
                new SelectListItem { Value = "3", Text = "2010 ADA" },
                new SelectListItem { Value = "4", Text = "Fair Housing Act" },
                new SelectListItem { Value = "5", Text = "CBC 2013 Chapter 11A" },
                new SelectListItem { Value = "6", Text = "CBC 2013 Chapter 11B" },
                new SelectListItem { Value = "7", Text = "CBC 2016 Chapter 11A" },
                new SelectListItem { Value = "8", Text = "CBC 2016 Chapter 11B" },
                new SelectListItem { Value = "9", Text = "CBC 2019 Chapter 11A" },
                new SelectListItem { Value = "10", Text = "CBC 2019 Chapter 11B" },
                new SelectListItem { Value = "11", Text = "Community Development Department of County of Los Angeles Universal Design Principles" },
                new SelectListItem { Value = "12", Text = "California Tax Credit Allocation Committee Regulations 50% Mobility Units" },
                new SelectListItem { Value = "13", Text = "UFAS" },
                new SelectListItem { Value = "14", Text = "Enhanced Accessiblity Program (EAP)" },
                new SelectListItem { Value = "15", Text = "2019 CBC w/ intervening cycle effective July 1st, 2021" },
                new SelectListItem { Value = "16", Text = "LACDA NOFA" },
                new SelectListItem { Value = "17", Text = "TCAC Universal Design" },
                new SelectListItem { Value = "18", Text = "CBC 2022 Chapter 11A" },
                new SelectListItem { Value = "19", Text = "CBC 2022 Chapter 11B" }
            };
        }

        public async Task<bool> CreateSite(SiteInformationModel siteInformationModel, string UserName)
        {
            bool IsSiteCreated=false;

            try
            {
                // Build the request model for PCMS site provisioning
                var siteRequest = new SiteProvisionRequest
                {
                    PcmsProjectId = siteInformationModel.RefProjectID,
                    ExistingPcmsSiteAddressId = siteInformationModel.RefSiteaddressID,
                    PrimaryAPN = siteInformationModel.APN,
                    FileNumber = siteInformationModel.FileNumber,
                    PropertyName = siteInformationModel.PropertyName,
                    UserName = UserName,
                    //ProjectAddress = siteInformationModel.ProjectAddress,

                    // Address parts
                    HouseNum = siteInformationModel.HouseNum,
                    HouseFracNum = siteInformationModel.HouseFracNum,
                    PreDirCd = siteInformationModel.LutPreDirCd,
                    StreetName = siteInformationModel.StreetName,
                    StreetTypeCd = siteInformationModel.LutStreetTypeCD,
                    PostDirCd = siteInformationModel.PostDirCd,
                    City = siteInformationModel.City,
                    Zip = siteInformationModel.Zip
                };

                // --- Call PCMS for site provisioning ---
                var pcmsSiteResult = await ProvisionSiteforPCMS(siteRequest);

                if (pcmsSiteResult == null ||
                    pcmsSiteResult.SiteAddressId <= 0 ||
                    pcmsSiteResult.ProjectSiteId <= 0 /* ensure your response also includes FileNumber */)
                {
                    // _logger.LogWarning("PCMS site creation failed: {0}", pcmsSiteResult?.ErrorMessage);
                    return false;
                }

                // local helpers
                object DbNullIfNull(object v) => v ?? (object)DBNull.Value;
                object DbNullIfEmpty(string s) => string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s;

                // IMPORTANT: this should be a LOCAL SiteAddressID if you have it; otherwise let AAHR mirror from PCMS
                object existingLocalSiteAddressId = DBNull.Value; // replace if you actually have SiteAddressID on your model

                // Build params for AAHR "provision from PCMS" SP
                var sqlParameters = new List<SqlParameter>
                {
                    // AAHR context
                    new SqlParameter("@ProjectID", siteInformationModel.ProjectID),
                    new SqlParameter("@PropertyName", DbNullIfEmpty(siteInformationModel.PropertyName)),
                    new SqlParameter("@PrimaryAPN", DbNullIfEmpty(siteInformationModel.APN)),
                    new SqlParameter("@ProjectCaseID", siteInformationModel.CaseID),
                    new SqlParameter("@SiteaddressID", SqlDbType.Int)
                        {
                            Value = string.IsNullOrWhiteSpace(siteInformationModel.SiteAddress)
                                ? (object)DBNull.Value
                                : (int.TryParse(siteInformationModel.SiteAddress.Trim(), out var id) ? (object)id : DBNull.Value)
                        },
                    new SqlParameter("@Source", "ACHP TPP"),

                    // PCMS outputs (be sure your PCMS response includes FileNumber)
                    new SqlParameter("@RefProjectID", siteInformationModel.RefProjectID),                 // PCMS ProjectID
                    new SqlParameter("@RefSiteAddressID", pcmsSiteResult.SiteAddressId),                 // PCMS SiteAddressID
                    new SqlParameter("@RefProjectSiteID", pcmsSiteResult.ProjectSiteId),                 // PCMS ProjectSiteID
                    new SqlParameter("@PCMS_FileNumber", DbNullIfEmpty(pcmsSiteResult.FileNumber)),      // from PCMS
                    new SqlParameter("@PCMS_FullAddress", DbNullIfEmpty(pcmsSiteResult.FullAddress)),    // from PCMS

                    // Optional address parts (assist local mirroring)
                    new SqlParameter("@HouseNum", DbNullIfEmpty(siteInformationModel.HouseNum)),
                    new SqlParameter("@HouseFracNum", DbNullIfEmpty(siteInformationModel.HouseFracNum)),
                    new SqlParameter("@PreDirCd", DbNullIfEmpty(siteInformationModel.LutPreDirCd)),
                    new SqlParameter("@StreetName", DbNullIfEmpty(siteInformationModel.StreetName)),
                    new SqlParameter("@StreetTypeCd", DbNullIfEmpty(siteInformationModel.LutStreetTypeCD)),
                    new SqlParameter("@PostDirCd", DbNullIfEmpty(siteInformationModel.PostDirCd)),
                    new SqlParameter("@City", DbNullIfEmpty(siteInformationModel.City)),
                    new SqlParameter("@Zip", DbNullIfEmpty(siteInformationModel.Zip)),

                    // CMS/IMS defaults
                    new SqlParameter("@SiteCaseTypeId", 18),
                    new SqlParameter("@SiteCaseType", "New Construction Site"),
                    new SqlParameter("@SiteCaseStatus", "Under Design Review"),
                    new SqlParameter("@LutServiceRequestTypeID_SITE", 18),

                    new SqlParameter("@UserName", DbNullIfEmpty(UserName))
                };

                // Call the new AAHR proc
                var dt = ExecuteStoreProcedure("[AAHPCC].[uspCreateProjectSite_dev]", sqlParameters);
                if (dt.Rows.Count > 0)
                {
                    IsSiteCreated = Convert.ToBoolean(dt.Rows[0]["Success"]);
                }

                return IsSiteCreated;
            }
            catch (Exception ex)
            {
                // Log or handle any unexpected error
                // _logger.LogError(ex, "Error creating site for project {0}", siteInformationModel.PcmsProjectId);
                return false;
            }

        }


        public async Task<SiteProvisionResponse> ProvisionSiteforPCMS(SiteProvisionRequest request, CancellationToken ct = default)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_config["AreaMgmtAPIURL:PropertyApiURL"]),
                Timeout = TimeSpan.FromSeconds(60)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Optional trace/auth headers
            var correlationId = Guid.NewGuid().ToString("N");
            client.DefaultRequestHeaders.Add("X-Correlation-ID", correlationId);
            var apiKey = _config["AreaMgmtAPIURL:ApiKey"];
            if (!string.IsNullOrWhiteSpace(apiKey))
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

            // Build payload for PCMS API (NO FileNumber — PCMS will compute)
            var payload = new
            {
                PcmsProjectId = request.PcmsProjectId,
                ExistingPcmsSiteAddressId = request.ExistingPcmsSiteAddressId,   // int? or null
                PrimaryAPN = Cap(request.PrimaryAPN, 100),
                PropertyName = Cap(request.PropertyName, 200),
                UserName = Cap(request.UserName, 100),
                ProjectAddress = Cap(request.ProjectAddress, 500),
                HouseNum = Cap(request.HouseNum, 10),
                HouseFracNum = Cap(request.HouseFracNum, 10),
                PreDirCd = Cap(request.PreDirCd, 2),
                StreetName = Cap(request.StreetName, 100),
                StreetTypeCd = Cap(request.StreetTypeCd, 10),
                PostDirCd = Cap(request.PostDirCd, 2),
                City = Cap(request.City, 100),
                Zip = Cap(request.Zip, 10)
            };

            var body = JsonConvert.SerializeObject(payload);
            using (var content = new StringContent(body, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage httpResponse;
                try
                {
                    // POST to your PCMS site endpoint (adjust route if different)
                    httpResponse = await client.PostAsync("AcHP/ProvisionSite", content, ct).ConfigureAwait(false);
                }
                catch (TaskCanceledException ex)
                {
                    return new SiteProvisionResponse
                    {
                        SiteAddressId = 0,
                        ProjectSiteId = 0,
                        FullAddress = string.Empty,
                        FileNumber = string.Empty,
                        CorrelationId = "ERR-" + correlationId,
                        ErrorMessage = "Timed out or canceled: " + ex.Message,
                        ErrorCode = "Timeout"
                    };
                }
                catch (HttpRequestException ex)
                {
                    return new SiteProvisionResponse
                    {
                        SiteAddressId = 0,
                        ProjectSiteId = 0,
                        FullAddress = string.Empty,
                        FileNumber = string.Empty,
                        CorrelationId = "ERR-" + correlationId,
                        ErrorMessage = "HTTP error: " + ex.Message,
                        ErrorCode = "HttpError"
                    };
                }

                var json = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return new SiteProvisionResponse
                    {
                        SiteAddressId = 0,
                        ProjectSiteId = 0,
                        FullAddress = string.Empty,
                        FileNumber = string.Empty,
                        CorrelationId = "ERR-" + correlationId,
                        ErrorCode = ((int)httpResponse.StatusCode).ToString(),
                        ErrorMessage = string.IsNullOrWhiteSpace(json) ? "PCMS site API failed." : json
                    };
                }

                // Parse BaseResponse-wrapped payload
                try
                {
                    var loose = JsonConvert.DeserializeObject<BaseResponse>(json);
                    if (loose == null || loose.Response == null)
                    {
                        return new SiteProvisionResponse
                        {
                            SiteAddressId = 0,
                            ProjectSiteId = 0,
                            FullAddress = string.Empty,
                            FileNumber = string.Empty,
                            CorrelationId = "ERR-" + correlationId,
                            ErrorMessage = "Empty BaseResponse.",
                            ErrorCode = "NoContent"
                        };
                    }

                    SiteProvisionResponse siteResponse = null;
                    var token = loose.Response as JToken;
                    if (token != null)
                    {
                        siteResponse = token.ToObject<SiteProvisionResponse>();
                    }
                    else
                    {
                        var respString = loose.Response.ToString();
                        siteResponse = JsonConvert.DeserializeObject<SiteProvisionResponse>(respString);
                    }

                    // Ensure correlation id is set
                    if (siteResponse != null && string.IsNullOrWhiteSpace(siteResponse.CorrelationId))
                        siteResponse.CorrelationId = correlationId;

                    // Make sure FileNumber is present (API should return it; if not, set empty)
                    if (siteResponse != null && siteResponse.FileNumber == null)
                        siteResponse.FileNumber = string.Empty;

                    return siteResponse ?? new SiteProvisionResponse
                    {
                        SiteAddressId = 0,
                        ProjectSiteId = 0,
                        FullAddress = string.Empty,
                        FileNumber = string.Empty,
                        CorrelationId = "ERR-" + correlationId,
                        ErrorMessage = "Unable to parse site provisioning result.",
                        ErrorCode = "ParseError"
                    };
                }
                catch (Exception ex2)
                {
                    return new SiteProvisionResponse
                    {
                        SiteAddressId = 0,
                        ProjectSiteId = 0,
                        FullAddress = string.Empty,
                        FileNumber = string.Empty,
                        CorrelationId = "ERR-" + correlationId,
                        ErrorMessage = "Parsing error: " + ex2.Message,
                        ErrorCode = "JsonParseError"
                    };
                }
            }
        }

        /// <summary>
        /// Truncates a string to the specified maximum length.
        /// Returns null if input is null or whitespace.
        /// </summary>
        private static string Cap(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            return input.Length <= maxLength
                ? input
                : input.Substring(0, maxLength);
        }


        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DataTable ExecuteStoreProcedure(string procedureName, List<SqlParameter> parameters)
        {
            return _storedProcedureExecutor.ExecuteStoreProcedure(procedureName, parameters);
        }


        /// <summary>
        /// SetBuildingReferenceData
        /// </summary>
        /// <param name="model"></param>
        private async Task SetBuildingReferenceData(UnitDataModel model)
        {
            List<PropSnapshot> propSnapshots = await _projectDetailRepository.PropSnapshotByBuilding(model.BuildingId);
            foreach (var i in propSnapshots)
            {
                var siteAddressId = i.SiteAddressId;
                model.APNId = i.Apnid;
                model.BuildingId = i.StructureId.Value;
                model.SiteAddressID = i.SiteAddressId;
                model.ProjectId = i.ProjectId;
                model.ProjectSiteId = i.ProjectSiteId;
                model.LevelId = i.LevelId;
                if (i.ServiceRequests.Any())
                {
                    model.CaseId = i.ServiceRequests.First().CaseId;
                }
            }
        }

     


        #endregion

    }
}
