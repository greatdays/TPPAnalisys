using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Entity.ViewModel;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IProjectDetailService
    {
        /// <summary>
        /// GetProjectSummary
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        ProjectSummaryModel GetProjectSummary(int caseId, string userName = "");

        /// <summary>
        /// GetProjectAssessors
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        List<string> GetProjectAssessors(int ProjectId);

        /// <summary>
        /// GetUnitMatrixDetails
        /// </summary>
        /// <param name="gridRequestModel"></param>
        /// <returns></returns>
        List<UnitDataModel> GetUnitMatrixDetails(GridRequestModel gridRequestModel);

        /// <summary>
        ///  SetUnitCountDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <returns></returns>
        TotalUnitDataModel SetUnitCountDetails(List<UnitDataModel> unitModel);

        /// <summary>
        /// GetSiteInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<SiteInformationModel> GetSiteInformation(int caseId, string userName);

        /// <summary>
        /// GetControlViewModelById
        /// </summary>
        /// <param name="controlViewModelId"></param>
        /// <returns></returns>
        ControlViewModel GetControlViewModelById(int controlViewModelId);

        /// <summary>
        /// UpdateUnitDetails
        /// </summary>
        /// <param name="unitModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> UpdateUnitDetails(UnitDataModel unitModel, string userName);

        /// <summary>
        /// AddUnitDetail
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<bool> AddUnitDetail(UnitDataModel model, string Username);
        /// <summary>
        /// DeleteUnit
        /// </summary>
        /// <param name="propId"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<bool> DeleteUnit(int propId, string User);

        /// <summary>
        /// Get Project actions by Case Id and logged in user roles
        /// </summary>
        /// <param name="caseId">Case Id</param>
        /// <param name="roles">Comma Separated Role Names</param>
        /// <returns>List of action names</returns>
        string GetProjectActionsByCaseId(int caseId, string roles);

        /// <summary>
        /// GetBuildingInformation
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        List<BuildingParkingInformationModal> GetBuildingInformation(int caseId);

        /// <summary>
        /// SaveLADBSData
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="models"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<string> SaveLADBSData(int propSnapshotId, List<PcisPermitDetail> models, string userName);

        /// <summary>
        /// GetAllPermitNumbers
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        Task<List<string>> GetAllPermitNumbers(int propSnapshotId);
        /// <summary>
        /// GetLADBSPermitNumberList
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        Task<List<string>> GetLADBSPermitNumberList(int propSnapshotId);

        /// <summary>
        /// GetLADBSDataByPermitNumber
        /// </summary>
        /// <param name="PermitNumber"></param>
        /// <param name="Department"></param>
        /// <returns></returns>
        Task<PcisPermitDetail> GetLADBSDataByPermitNumber(string PermitNumber, string Department);

        /// <summary>
        /// GetLADBSPermitDetails
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="permitNumber"></param>
        /// <returns></returns>
        Task<PcisPermitDetail> GetLADBSPermitDetails(int propSnapshotId, string permitNumber);

        /// <summary>
        /// GetLutTotalBedrooms
        /// </summary>
        /// <returns></returns>
        Task<List<SelectListItem>> GetLutTotalBedrooms();

        /// <summary>
        /// GetLutUnitType
        /// </summary>
        /// <returns></returns>
        Task< List<SelectListItem>> GetLutUnitType();

        /// <summary>
        /// GetPropSnapshotDetails
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        Task<BuildingModel> GetPropSnapshotDetails(int projectSiteId);
        List<string> GetReviewNote(int caseId);

        Task<bool> CreateSite(SiteInformationModel siteInformationModel, string UserName);

        Task<ProjectSummaryModel> GetProjectSiteDetails(int projectId);
    }
}
