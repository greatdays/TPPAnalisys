using DeveloperPortal.DataAccess.Entity.ViewModel;
using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        bool UpdateUnitDetails(UnitDataModel unitModel, string userName);

        /// <summary>
        /// AddUnitDetail
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        bool AddUnitDetail(UnitDataModel model, string Username);
        /// <summary>
        /// DeleteUnit
        /// </summary>
        /// <param name="propId"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        bool DeleteUnit(int propId, string User);

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
        /// GetLADBSPermitNumberList
        /// </summary>
        /// <param name="PropsnapshotId"></param>
        /// <returns></returns>
        List<string> GetLADBSPermitNumberList(int PropsnapshotId);

        /// <summary>
        /// GetLutTotalBedrooms
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetLutTotalBedrooms();
        
        /// <summary>
        /// GetLutUnitType
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetLutUnitType();

    }
}
