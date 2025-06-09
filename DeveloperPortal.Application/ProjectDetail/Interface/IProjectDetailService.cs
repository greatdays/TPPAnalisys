using DeveloperPortal.DataAccess.Entity.ViewModel;
using DeveloperPortal.Domain.ProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
