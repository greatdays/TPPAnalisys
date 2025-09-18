using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DeveloperPortal.Controllers
{   
    public class ProjectDetailController : Controller
    {
        #region Construtor

        private IProjectDetailService _projectDetailService;
        private IUnitImportService _unitImportService;
        private readonly IWebHostEnvironment _env;
        private readonly string UserName;

        public ProjectDetailController(IProjectDetailService projectDetailService, IUnitImportService unitImportService, IWebHostEnvironment env)
        {
            _projectDetailService = projectDetailService;
            _unitImportService = unitImportService;
            _env = env;
            //Username = UserSession.GetUserSession().UserName
            UserName = "jhirpara";
        }

        #endregion

        #region Unit Information

        /// <summary>
        /// GetUnitDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetUnitDetails([FromBody] GridRequestModel gridRequestModel)
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

        /// <summary>
        /// GetUnitModalData
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetUnitModalData()
        {
            var lutUnitType = await _projectDetailService.GetLutUnitType();
            var lutTotalBedrooms = await _projectDetailService.GetLutTotalBedrooms();
            return Json(new { LutUnitType = lutUnitType, LutTotalBedrooms = lutTotalBedrooms });
        }


        /// <summary>
        /// UpdateUnitDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UpdateUnitDetails([FromBody] List<UnitDataModel> updateModels)
        {
            var result = false;
            try
            {
                if (updateModels != null && updateModels.Count > 0)
                {
                    var updateModel = updateModels[0];
                    result = await _projectDetailService.UpdateUnitDetails(updateModel, UserName);
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
        public async Task<JsonResult> DeleteUnitDetail([FromBody] List<UnitDataModel> deleteModels)
        {
            var result = false;
            try
            {
                if (deleteModels != null && deleteModels.Count > 0)
                {
                    result = await _projectDetailService.DeleteUnit(deleteModels[0].PropSnapshotID, UserName);
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
        public async Task<JsonResult> AddUnitDetail([FromBody] List<UnitDataModel> addModels)
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
                        result = await _projectDetailService.AddUnitDetail(saveMode, UserName);
                    }
                }

                return Json(new { success = result, isRefreshGrid = true, message = "Record Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = result, isRefreshGrid = true, message = ex.Message });
            }
        }


        /// <summary>
        /// ImportUnitInformation
        /// </summary>
        /// <param name="file"></param>
        /// <param name="projectId"></param>
        /// <param name="projectSiteID"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ImportUnitInformation(List<IFormFile> file, [FromForm] int projectId, [FromForm] int projectSiteID, [FromForm] int Id)
        {

            JsonData<JsonStatus> result = new JsonData<JsonStatus>(new JsonStatus());
            result.Result.Status = false;
            var caseId = Id;
            try
            {
                if (file != null)
                {
                    var postedFile = file[0];
                    if (postedFile.ContentType == "application/vnd.ms-excel" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string fileName = $"UnitInformation_{projectId}_{projectSiteID}_upload.xlsx";
                        string targetPath = Path.Combine(_env.WebRootPath, "Document");
                        string fullPath = Path.Combine(targetPath, fileName);

                        // Ensure directory exists
                        if (!Directory.Exists(targetPath))
                            Directory.CreateDirectory(targetPath);

                        // Delete file if it already exists
                        if (System.IO.File.Exists(fullPath))
                            System.IO.File.Delete(fullPath);

                        // Save the uploaded file
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await postedFile.CopyToAsync(stream);
                        }

                        var excelData = await _unitImportService.ReadExcelData(fullPath);
                        //validate the import is correct nor error..
                        if (excelData.Tables.Count == 2)
                        {
                            //Import data to database 
                            var dtResult = await _unitImportService.ExecuteImportUnitInfoAsync(excelData, caseId, UserName);
                            var totalRecord = dtResult.Rows.Count;
                            dtResult.DefaultView.RowFilter = "Status ='Success'";
                            var validRecord = dtResult.DefaultView.Count;
                            var inValidRecord = totalRecord - validRecord;
                            fileName = $"UnitInformation_{projectId}_{projectSiteID}_upload_result.xlsx";
                            fullPath = targetPath + "/" + fileName;

                            StringBuilder tableHtml = _unitImportService.ShowExportDataResult(dtResult);

                            string baseMessage = "Unit information has been uploaded successfully." +
                                                 "<br><br>Note: Valid Records: " + validRecord + "/" + totalRecord +
                                                 " and Invalid Records: " + inValidRecord + "/" + totalRecord;

                            result.Result.Message = baseMessage + tableHtml.ToString();
                            result.Result.Status = true;
                        }
                        else
                        {
                            result.Result.ErrorMessage = "Invalid Data Found in excel sheet.";
                        }
                    }
                    else
                    {
                        result.Result.ErrorMessage = "Invalid uploaded file";
                    }
                }
                else
                {
                    result.Result.ErrorMessage = "Please select valid excel file";
                }
                return Json(result);
            }
            catch (Exception ex)
            {

                result.Result.ErrorMessage = "The uploaded file is invalid. Please upload a valid Excel file as per the sample format and try again.";
                return new JsonResult(result);
            }

        }

        #endregion

        #region Building Information

        /// <summary>
        /// GetBuildingInformation
        /// </summary>
        /// <param name="paramModel"></param>
        /// <param name="caseId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetBuildingInformation([FromForm] BuildingInformationParamModel paramModel, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
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
        /// GetPermitNumbers
        /// </summary>
        /// <param name="PropSnapshotID"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="draw"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<JsonResult> GetPermitNumbers([FromForm] int PropSnapshotID, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
        {

            List<string> permitList = await _projectDetailService.GetLADBSPermitNumberList(PropSnapshotID);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="PermitNumber"></param>
        /// <param name="Department"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetPermitDetails(int propSnapshotId, string PermitNumber)
        {

            PcisPermitDetail pcisPermitDetail = await _projectDetailService.GetLADBSPermitDetails(propSnapshotId, PermitNumber);

            string html = this.RenderViewAsync("../ProjectDetail/GetPermitDetails", pcisPermitDetail, true).Result;

            return Json(html);
        }

        /// <summary>
        /// SaveLADBSData
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="permitNumber"></param>
        /// <param name="Delete"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> SaveLADBSData(int propSnapshotId, string permitNumber, bool Delete = false)
        {
            try
            {
                List<string> inValidPermitNumbers = new List<string>();
                string status = string.Empty;
                if (string.IsNullOrEmpty(permitNumber)) // option to use all existing permit numbers on the building
                {
                    List<string> PermitNumbers = await _projectDetailService.GetAllPermitNumbers(propSnapshotId);
                    PermitNumbers = RemoveUnWantedSpaceComma(PermitNumbers);
                    List<PcisPermitDetail> data = new List<PcisPermitDetail>();
                    foreach (string permit in PermitNumbers)
                    {
                        PcisPermitDetail model = await _projectDetailService.GetLADBSDataByPermitNumber(permit, "HPP");
                        if (model != null)
                        {
                            data.Add(model);
                        }
                        else
                        {
                            inValidPermitNumbers.Add(permit);
                        }
                    }
                    status = await _projectDetailService.SaveLADBSData(propSnapshotId, data, UserName);
                    return Json(new
                    {
                        valid = string.Join(", ", PermitNumbers),
                        invalid = inValidPermitNumbers
                    });
                }
                else if (!Delete) // option to get LADBS data using entered permit number
                {
                    PcisPermitDetail model = await _projectDetailService.GetLADBSDataByPermitNumber(permitNumber, "HPP");
                    if (model != null)
                    {
                        model.Delete = Delete;
                        List<PcisPermitDetail> data = new List<PcisPermitDetail>() { model };
                        status = await _projectDetailService.SaveLADBSData(propSnapshotId, data, UserName);
                        return Json(status);
                    }
                    else
                    {
                        inValidPermitNumbers.Add(permitNumber);
                        return Json(new
                        {
                            valid = string.Join(", ", permitNumber),
                            invalid = inValidPermitNumbers
                        });
                    }


                }
                else // option to delete permit number
                {
                    PcisPermitDetail model = new PcisPermitDetail()
                    {
                        Department = "HPP",
                        PermitNumber = permitNumber,
                        Delete = Delete
                    };

                    List<PcisPermitDetail> data = new List<PcisPermitDetail>() { model };
                    status = await _projectDetailService.SaveLADBSData(propSnapshotId, data, UserName);
                    return Json(status);
                }
            }
            catch
            {
                return Json("No records found. Wrong Permit # or Department");
            }
        }

        /// <summary>
        /// UpdateParkingDetail
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult> UpdateParkingDetail([FromForm] BuildingParkingInformationModal buildingModel)
        {
            try
            {
                var result = false;
                if (buildingModel != null && buildingModel.PropSnapshotID > 0)
                {
                    result = await _projectDetailService.SaveBuildingParkingAttributes(buildingModel, UserName);
                }
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        #endregion

        #region Project Site Information

        /// <summary>
        /// GetSiteInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetSiteInformation([FromForm] SiteInformationParamModel paramModel, [FromForm] int start, [FromForm] int length, [FromForm] int draw)
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

        #endregion


        #region Private Methods


        /// <summary>
        /// SortData UnitDataModel
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <param name="unitModels"></param>
        /// <returns></returns>
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

        /// <summary>
        /// PadNumbers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string PadNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            { return input; }
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }

        /// <summary>
        /// removeUnWantedSpaceComma
        /// </summary>
        /// <param name="permitNumbers"></param>
        /// <returns></returns>
        private List<string> RemoveUnWantedSpaceComma(List<string> permitNumbers)
        {
            var cleanedPermitNumbers = permitNumbers
                .Where(s => !string.IsNullOrWhiteSpace(s))           // Remove null or empty strings
                .SelectMany(s => s.Split(','))                        // Split each by comma
                .Select(p => p.Trim())                                // Trim each permit number
                .Where(p => !string.IsNullOrWhiteSpace(p))            // Remove blanks after trim
                .ToList();

            return cleanedPermitNumbers;
        }
        #endregion

    }
}
