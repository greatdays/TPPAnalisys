using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperPortal.Controllers
{
    public class ProjectDetailController : Controller
    {
        #region Construtor

        private IConfiguration _config;
        private IHttpContextAccessor _contextAccessor;
        private IProjectDetailService _projectDetailService;

        public ProjectDetailController(IConfiguration configuration, IHttpContextAccessor contextAccessor, IProjectDetailService projectDetailService)
        {
            _config = configuration;
            _contextAccessor = contextAccessor;
            _projectDetailService = projectDetailService;
        }

        #endregion

        #region My Project Information Tab

        /// <summary>
        /// GetUnitDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetUnitDetails([FromBody] GridRequestModel gridRequestModel)
        {
            var unitModels = new List<UnitDataModel>();
            var isCalculateCount = true;
            if (gridRequestModel != null && gridRequestModel.UnitGridData != null && gridRequestModel.UnitGridData.Any())
            {
                isCalculateCount = false;
                unitModels = gridRequestModel.UnitGridData;
            }
            if (unitModels.Count == 0)
            {
                unitModels = _projectDetailService.GetUnitMatrixDetails(gridRequestModel);
            }
            TotalUnitDataModel totalUnitDetail = null;
            var buildingDropDownList = new List<UnitBuildingModel>();
            if (isCalculateCount)
            {
                totalUnitDetail = _projectDetailService.SetUnitCountDetails(unitModels);
                buildingDropDownList = unitModels.Select(unit => new UnitBuildingModel { ACHPNo = unit.ACHPNo, CaseId = unit.CaseId, BuildingId = unit.BuildingId }).Distinct().ToList();

            }
            //Sort Unit data
            unitModels = SortData(gridRequestModel, unitModels);

            var data = unitModels;
            if (gridRequestModel != null && gridRequestModel.Take > 0)
            {
                data = data.Skip(gridRequestModel.Skip).Take(gridRequestModel.Take).ToList();
            }
            return Json(new { data = data, unitGridData = unitModels, buildingDropDownList = buildingDropDownList, aggregates = new Dictionary<string, Dictionary<string, string>>(), _total = unitModels.Count, isGrouped = false, totalUnitsCount = totalUnitDetail });

        }
        [HttpGet]
        public JsonResult GetUnitModalData()
        {
            var unitModels = new List<UnitDataModel>();
            var lutUnitType = _projectDetailService.GetLutUnitType();
            var lutTotalBedrooms = _projectDetailService.GetLutTotalBedrooms();

            return Json(new { LutUnitType = lutUnitType, LutTotalBedrooms = lutTotalBedrooms });

        }

        private static List<UnitDataModel> SortData(GridRequestModel gridRequestModel, List<UnitDataModel> unitModels)
        {
            if (gridRequestModel != null && gridRequestModel.Sort != null && gridRequestModel.Sort.Count > 0)
            {
                var orderby = gridRequestModel.Sort[0].Field;
                var desc = gridRequestModel.Sort[0].Dir == "desc";

                switch (orderby.ToUpperInvariant())
                {
                    case "ACHPNO":
                        unitModels = desc ? unitModels.OrderByDescending(c => PadNumbers(c.ACHPNo)).ToList() : unitModels.OrderBy(c => PadNumbers(c.ACHPNo)).ToList();
                        break;
                    case "UNITNUM":
                        unitModels = desc ? unitModels.OrderByDescending(c => PadNumbers(c.UnitNum)).ToList() : unitModels.OrderBy(c => PadNumbers(c.UnitNum)).ToList();
                        break;
                    case "MANAGERSUNIT":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.ManagersUnit).ToList() : unitModels.OrderBy(c => c.ManagersUnit).ToList();
                        break;
                    case "TOTALBEDROOM":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.TotalBedroom).ToList() : unitModels.OrderBy(c => c.TotalBedroom).ToList();
                        break;
                    case "FLOORPLANTYPE":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.FloorPlanType).ToList() : unitModels.OrderBy(c => c.FloorPlanType).ToList();
                        break;
                    case "UNITTYPE":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.UnitType).ToList() : unitModels.OrderBy(c => c.UnitType).ToList();
                        break;
                    case "ADDITIONALACCECIBILITY":
                        unitModels = desc ? unitModels.OrderByDescending(c => PadNumbers(c.AdditionalAccecibility)).ToList() : unitModels.OrderBy(c => PadNumbers(c.AdditionalAccecibility)).ToList();
                        break;
                    case "ISCOMPLIANT":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.IsCompliant).ToList() : unitModels.OrderBy(c => c.IsCompliant).ToList();
                        break;
                    case "ISCSA":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.IsCSA).ToList() : unitModels.OrderBy(c => c.IsCSA).ToList();
                        break;
                    case "ISVCA":
                        unitModels = desc ? unitModels.OrderByDescending(c => c.IsVCA).ToList() : unitModels.OrderBy(c => c.IsVCA).ToList();
                        break;
                }
            }

            return unitModels;
        }

        public static string PadNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            { return input; }
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }

        /// <summary>
        /// UpdateUnitDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateUnitDetails([FromBody] List<UnitDataModel> updateModels)
        {
            var result = false;
            try
            {
                if (updateModels != null && updateModels.Count > 0)
                {
                    var updateModel = updateModels[0];
                    result = _projectDetailService.UpdateUnitDetails(updateModel,"jhirpara");
                }
                return Json(new { success = result, isRefreshGrid = true, message = "Record Updated Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Unit Detail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteUnitDetail([FromBody] List<UnitDataModel> deleteModels)
        {
            var result = false;
            try
            {
                if (deleteModels != null && deleteModels.Count > 0)
                {
                    result = _projectDetailService.DeleteUnit(deleteModels[0].PropSnapshotID, "jhirpara");
                }
                return Json(new { success = result, isRefreshGrid = true, message = "Record Deleted Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
            }

        }
        /// <summary>
        /// Add Unit Detail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUnitDetail([FromBody] List<UnitDataModel> addModels)
        {
            var result = false;
            try
            {
                if (addModels != null && addModels.Count > 0)
                {
                    var saveMode = addModels[0];
                    saveMode.UnitID = 0;
                    if (saveMode != null)
                    {
                        result = _projectDetailService.AddUnitDetail(saveMode, "jhirpara");
                    }
                }

                return Json(new { success = result, isRefreshGrid = true, message = "Record Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
            }
        }


        #endregion



        /// <summary>
        /// GetBuildingInformationsPost
        /// </summary>
        /// <param name="paramModel"></param>
        /// <param name="caseId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetBuildingInformation([FromForm] BuildingInformationParamModel paramModel, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
        {
            var total = 0;
            List<ParkingInformation> buildingData = new List<ParkingInformation>();
            if (paramModel == null)
            {
                return Json(new { draw = draw, data = buildingData, recordsTotal = total, recordsFiltered = total });
            }
            var buildingParkingInformations = paramModel.BuildingInformationData;

            if (paramModel.BuildingInformationData == null || paramModel.BuildingInformationData.Count == 0)
            {
                buildingParkingInformations = _projectDetailService.GetBuildingInformation(paramModel.CaseId);
            }

            if (buildingParkingInformations.Any())
            {
                total = buildingParkingInformations.Count;
            }

            var totalbuldingList = buildingParkingInformations.Select(x => x.BuildingFileNumber).Distinct().ToList();

            if (length > 0)
            {
                var selectedBuildingParkingInformations = buildingParkingInformations.Skip(start).Take(length).ToList();
                if (selectedBuildingParkingInformations.Any())
                {
                    foreach (var buildingParkingInformation in selectedBuildingParkingInformations)
                    {
                        buildingData.Add(new ParkingInformation
                        {
                            ParkingData = this.RenderViewAsync("../ProjectDetail/_ParkingInformation", buildingParkingInformation, true).Result,
                            BuildingFileNumber = buildingParkingInformation.BuildingFileNumber
                        });
                    }
                    buildingData[0].BuildingList = totalbuldingList;
                    buildingData[0].BuildingInformationData = buildingParkingInformations;

                }
            }
            return Json(new { draw = draw, data = buildingData, recordsTotal = total, recordsFiltered = total });
        }


        /// <summary>
        /// GetBuildingInformationsPost
        /// </summary>
        /// <param name="paramModel"></param>
        /// <param name="caseId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetBuildingInformation1()
        {
            var paramModel = new BuildingInformationParamModel();
            int start = 0;
            int length = 0;
            int draw = 0;
            var total = 0;
            var buildingParkingInformations = paramModel.BuildingInformationData;

            if (paramModel.BuildingInformationData == null || paramModel.BuildingInformationData.Count == 0)
            {
                buildingParkingInformations = _projectDetailService.GetBuildingInformation(paramModel.CaseId);
            }

            if (buildingParkingInformations.Any())
            {
                total = buildingParkingInformations.Count;
            }

            var totalbuldingList = buildingParkingInformations.Select(x => x.BuildingFileNumber).Distinct().ToList();
            List<ParkingInformation> buildingData = new List<ParkingInformation>();
            if (length > 0)
            {
                var selectedBuildingParkingInformations = buildingParkingInformations.Skip(start).Take(length).ToList();
                if (selectedBuildingParkingInformations.Any())
                {
                    foreach (var buildingParkingInformation in selectedBuildingParkingInformations)
                    {
                        buildingData.Add(new ParkingInformation
                        {
                            ParkingData = this.RenderViewAsync("../ProjectDetail/_ParkingInformation", buildingParkingInformation, true).Result,
                            BuildingFileNumber = buildingParkingInformation.BuildingFileNumber
                        });
                    }
                    buildingData[0].BuildingList = totalbuldingList;
                    buildingData[0].BuildingInformationData = buildingParkingInformations;

                }
            }
            return Json(new { draw = draw, data = buildingData, recordsTotal = total, recordsFiltered = total });
        }

        [HttpPost]
        public JsonResult GetPermitNumbersPost([FromForm] int PropSnapshotID, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
        {

            List<string> permitList= new List<string>();//= _projectDetailService.GetLADBSPermitNumberList(PropSnapshotID);

            List<PermitNumberInformation> data = new List<PermitNumberInformation>()
            {
                new PermitNumberInformation() {
                    PermitData = null,
                    PermitNumber = null,
                    PermitList = permitList
                }
            };

            return Json(new { draw = draw, data = data, recordsTotal = permitList.Count(), recordsFiltered = permitList.Count() });
        }

        [HttpGet]
        public JsonResult GetPermitDetails(int PropsnapshotID, string PermitNumber, string Department)
        {

            PcisPermitDetail pcisPermitDetail = new PcisPermitDetail();// _caseService.GetLADBSPermitDetails(PropsnapshotID, PermitNumber, Department);

            string html = this.RenderViewAsync("../ProjectDetail/GetPermitDetails", pcisPermitDetail, true).Result;

            return Json(html);
        }

        #region Project Site Information

        /// <summary>
        /// GetSiteInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSiteInformations([FromForm] SiteInformationParamModel paramModel, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
        {

            var total = 0;
            var siteInformation = paramModel.SiteInformationData;
            if (paramModel.SiteInformationData == null || paramModel.SiteInformationData.Count == 0)
            {
                siteInformation = _projectDetailService.GetSiteInformation(paramModel.CaseId, "");
            }

            if (siteInformation != null && siteInformation.Any())
            {
                total = siteInformation.Count;
            }

            var totalSiteList = siteInformation.Select(x => x.FileNumber).ToList();
            var siteData = new List<SiteDataModel>();
            if (length > 0)
            {
                var selectedsiteData = siteInformation.Skip(start).Take(length).ToList();
                if (selectedsiteData.Any())
                {
                    foreach (var siteIData in selectedsiteData)
                    {
                        siteIData.Actions = siteIData.Actions.Replace("&lt;", "<").Replace("&gt;", ">");
                        siteData.Add(new SiteDataModel()
                        {
                            Id = siteIData.CaseID,
                            ProjectId = siteIData.ProjectID,
                            DocumentControlViewModelId = siteIData.DocumentControlViewModelId,
                            LogsControlViewModelId = siteIData.LogsControlViewModelId,
                            ContactControlViewModelId = siteIData.ContactControlViewModelId,
                            SiteName = siteIData.SiteName,
                            FileNumber = siteIData.FileNumber,
                            SiteInfomationData = this.RenderViewAsync("../ProjectDetail/_SiteInformation", siteIData, true).Result
                        });
                    }
                    siteData[0].SiteList = totalSiteList;
                    siteData[0].SiteInformationData = siteInformation;
                }
            }
            return Json(new { draw = draw, data = siteData, recordsTotal = total, recordsFiltered = total });

        }

        #endregion


        /// <summary>
        /// Get Project actions by case Id and logged in user role.
        /// </summary>
        /// <param name="caseId">Case Id</param>        
        /// <param name="projectId">Project Id</param>
        /// <returns>Project actions anchor links</returns>
        [HttpGet]
        public ActionResult GetProjectActionsByCaseId(int caseId, int projectId)
        {

            List<string> roles = new List<string>()
            {
                "RCS |||",
                "RCS ||"
            };//UserSession.GetUserSession().Roles;
            string commaSeparatedRoles = String.Join(",", roles);
            string projectActions = "";// _projectDetailService.GetProjectActionsByCaseId(caseId, commaSeparatedRoles);
            string decodedActions = HttpUtility.HtmlDecode(projectActions);

            return Content(decodedActions);
        }

        public IActionResult RenderContactById(string projectId, int controlViewModelId)
        {
            DataAccess.Entity.ViewModel.ControlViewModel controlView = _projectDetailService.GetControlViewModelById(controlViewModelId);
            string? areaQueryString = Request.Query["area"];
            string? Id = areaQueryString?.Split('?')[1].Replace("Id=", string.Empty); //caseId

            RenderController renderController = new RenderController(_config);
            PartialViewResult result = renderController.RenderContact(controlView, Id);
            //return renderController.RenderContact(controlView, Id);
            return result;

            //return Json("{'data':'12'}");
        }

        //private JsonResult RenderContact(object controlView, object id)
        //{
        //    throw new NotImplementedException();
        //}
        [HttpGet]
        public bool HasRole(string key, DataAccess.Entity.ViewModels.ComCon.ContactDisplayConfig model)
        {
            bool hasRole = false;
            string response = string.Empty;
            JObject jsonObject = new JObject();
            //JObject[] jsonObjectArray = new JObject();


            switch (key)
            {
                case "ObsoleteRole":
                    hasRole = UserSession.GetUserSession(_contextAccessor.HttpContext).Roles.Any(x => model.MarkObsoleteRoleList.Contains(x));
                    jsonObject["Role"] = key;
                    jsonObject["hasRole"] = hasRole;
                    break;
                case "ValidRole":
                    hasRole = UserSession.GetUserSession(_contextAccessor.HttpContext).Roles.Any(x => model.MarkValidRoleList.Contains(x));
                    jsonObject["Role"] = key;
                    jsonObject["hasRole"] = hasRole;
                    break;
                case "InvalidRole":
                    hasRole = UserSession.GetUserSession(_contextAccessor.HttpContext).Roles.Any(x => model.MarkInValidRoleList.Contains(x));
                    jsonObject["Role"] = key;
                    jsonObject["hasRole"] = hasRole;
                    break;
                case "MailForwardingRole":
                    hasRole = UserSession.GetUserSession(_contextAccessor.HttpContext).Roles.Any(x => model.MarkMailForwardingRoleList.Contains(x));
                    jsonObject["Role"] = key;
                    jsonObject["hasRole"] = hasRole;
                    break;
                case "All":
                    hasRole = UserSession.GetUserSession(_contextAccessor.HttpContext).Roles.Any(x => model.MarkObsoleteRoleList.Contains(x));
                    jsonObject = new JObject
                    {

                    };
                    jsonObject["Role"] = key;
                    jsonObject["hasRole"] = hasRole;
                    break;
                default:
                    hasRole = false;
                    break;
            }

            //return JsonConvert;
            return hasRole;
        }
    }

    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }

}
