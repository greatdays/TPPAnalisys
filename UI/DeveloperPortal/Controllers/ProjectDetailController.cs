using ComCon.DataAccess.ViewModel;
using DeveloperPortal.Application;
using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.ViewModels.ComCon;

//using DeveloperPortal.Domain.Models;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperPortal.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProjectDetailController : Controller
    {
        private IConfiguration _config;
        private IHttpContextAccessor _contextAccessor;

        public ProjectDetailController(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _config = configuration;
            _contextAccessor = contextAccessor;
        }
        #region My Project Information Tab

        /// <summary>
        /// GetUnitDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetUnitDetails(GridRequestModel gridRequestModel)
        {
            var projectDetailService = new ProjectDetailService(_config);
            var unitModels = new List<UnitDataModel>();
            var isCalculateCount = true;
            if (gridRequestModel!= null && gridRequestModel.UnitGridData != null && gridRequestModel.UnitGridData.Any())
            {
                isCalculateCount = false;
                unitModels = gridRequestModel.UnitGridData;
            }
            if (unitModels.Count == 0)
            {
                //Ananth commented for testing
                //unitModels = projectDetailService.GetUnitMaxtrixDetails(gridRequestModel);
            }
            TotalUnitDataModel totalUnitDetail = null;
            var buildingDropDownList = new List<UnitBuildingModel>();
            if (isCalculateCount)
            {
                totalUnitDetail = projectDetailService.SetUnitCountDetails(unitModels);
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


        
        private static List<UnitDataModel> SortData(GridRequestModel gridRequestModel, List<UnitDataModel> unitModels)
        {
            if (gridRequestModel!= null && gridRequestModel.Sort != null && gridRequestModel.Sort.Count > 0)
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
        public JsonResult UpdateUnitDetails()
        {

            var result = false;
            try
            {
                var requstModels = Request.Form["models"];
                var updateModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UnitDataModel>>(requstModels);
                //if (updateModels != null && updateModels.Count > 0)
                //{
                //    var updateModel = updateModels[0];
                //    result = _caseDetailService.UpdateUnitDetails(updateModel, UserSession.GetUserSession().UserName);
                //}
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
        public JsonResult DeleteUnitDetail()
        {
            var result = false;
            try
            {
                var requstModels = Request.Form["models"];
                var deleteModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UnitDataModel>>(requstModels);
                //if (deleteModels != null && deleteModels.Count > 0)
                //{
                //    result = _caseService.DeleteUnit(deleteModels[0].PropSnapshotID, UserSession.GetUserSession().UserName);
                //}

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
        public JsonResult AddUnitDetail()
        {
            var result = false;
            try
            {
                var requstModels = Request.Form["models"];
                var addModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UnitDataModel>>(requstModels);
                if (addModels != null && addModels.Count > 0)
                {
                    var saveMode = addModels[0];
                    saveMode.UnitID = 0;
                    //if (saveMode != null)
                    //{
                    //    result = _caseDetailService.AddUnitDetail(saveMode, UserSession.GetUserSession().UserName);
                    //}
                }

                return Json(new { success = result, isRefreshGrid = true, message = "Record Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
            }
        }


        #endregion

        #region Project Site Information

        /// <summary>
        /// GetSiteInformations
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSiteInformations(SiteInformationParamModel paramModel, int start, int length, int draw)
        {

            var total = 0;
            var siteInformations = paramModel.SiteInformationData;
            var projectDetailService = new ProjectDetailService(_config);
            if (paramModel.SiteInformationData == null || paramModel.SiteInformationData.Count == 0)
            {
                siteInformations = projectDetailService.GetSiteInformations(paramModel.CaseId, "");
            }

            if (siteInformations != null && siteInformations.Any())
            {
                total = siteInformations.Count;
            }

            var totlaSiteList = siteInformations.Select(x => x.FileNumber).ToList();
            var siteData = new List<SiteDataModel>();
            if (length > 0)
            {
                var SelectedsiteData = siteInformations.Skip(start).Take(length).ToList();
                if (SelectedsiteData.Any())
                {
                    foreach (var siteInformation in SelectedsiteData)
                    {
                        siteInformation.Actions = siteInformation.Actions.Replace("&lt;", "<").Replace("&gt;", ">");
                        siteData.Add(new SiteDataModel()
                        {
                            Id = siteInformation.CaseID,
                            ProjectId = siteInformation.ProjectID,
                            DocumentControlViewModelId = siteInformation.DocumentControlViewModelId,
                            LogsControlViewModelId = siteInformation.LogsControlViewModelId,
                            ContactControlViewModelId = siteInformation.ContactControlViewModelId,
                            SiteName = siteInformation.SiteName,
                            FileNumber = siteInformation.FileNumber,
                            SiteInfomationData = this.RenderViewAsync("../ProjectDetail/_SiteInformation", siteInformation,true).Result
                        });
                    }
                    siteData[0].SiteList = totlaSiteList;
                    siteData[0].SiteInformationData = siteInformations;
                }
            }
            return Json(new { draw = draw, data = siteData, recordsTotal = total, recordsFiltered = total });

        }

        #endregion

        public IActionResult RenderContactById(string projectId, int controlViewModelId)
        {
            ProjectDetailService detailService = new ProjectDetailService(_config);
            DataAccess.Entity.ViewModel.ControlViewModel controlView = detailService.GetControlViewModelById(controlViewModelId);
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
                    jsonObject = new JObject { 

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
