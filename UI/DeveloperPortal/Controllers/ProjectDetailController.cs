using DeveloperPortal.Application;
using DeveloperPortal.DataAccess;
using DeveloperPortal.Domain.Models;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        #region My Project Information Tab

        /// <summary>
        /// GetUnitDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetUnitDetails(GridRequestModel gridRequestModel)
        {
            var projectDetailService = new ProjectDetailService();
            var unitModels = new List<UnitDataModel>();
            var isCalculateCount = true;
            if (gridRequestModel!= null && gridRequestModel.UnitGridData != null && gridRequestModel.UnitGridData.Any())
            {
                isCalculateCount = false;
                unitModels = gridRequestModel.UnitGridData;
            }
            if (unitModels.Count == 0)
            {
                unitModels = projectDetailService.GetUnitMaxtrixDetails(gridRequestModel);
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
    }


}
