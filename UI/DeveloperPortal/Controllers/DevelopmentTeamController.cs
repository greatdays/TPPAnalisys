
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Extensions;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using ContactRenderModel = DeveloperPortal.Domain.ProjectDetail.ContactRenderModel;

namespace DeveloperPortal.Controllers
{
    public class DevelopmentTeamController : Controller
    {
        private IDevelopmentTeamService _developmentTeamService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string UserName;
        public DevelopmentTeamController(IDevelopmentTeamService developmentTeamService, IHttpContextAccessor httpContextAccessor)
        {
            _developmentTeamService = developmentTeamService;
            _httpContextAccessor = httpContextAccessor;
            UserName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            UserName = string.IsNullOrEmpty(UserName) ? "" : UserName;
        }

        #region public method
        /// <summary>
        /// DevelopmentTeamList
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="caseId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> List(int projectId, int caseId)
        {
            var data = await _developmentTeamService.DevelopmentTeamList(projectId, caseId, "");
            string html = this.RenderViewAsync("../DevelopmentTeam/DevelopmentTeamList", data, true).Result;
            return Json(html);
        }

        [HttpPost]
        public async Task<JsonResult> AddContact(string apn, int caseId, int projectId = 0, int projectSiteId = 0)
        {
            var contactRenderModel = new ContactRenderModel();
            contactRenderModel = await _developmentTeamService.GetContactDetail(0, apn, caseId, projectId, projectSiteId);
            string html = this.RenderViewAsync("../DevelopmentTeam/AddContact", contactRenderModel, true).Result;
            return Json(html);
        }

        [HttpPost]
        public async Task<JsonResult> EditContact(int contactIdentifierId, string apn, int caseId, string companyName, int projectId = 0, int projectSiteId = 0)
        {
            var contactRenderModel = new ContactRenderModel();
            contactRenderModel = await _developmentTeamService.GetContactDetail(contactIdentifierId, apn, caseId, projectId, projectSiteId);
            contactRenderModel.Company = companyName;
            string html = this.RenderViewAsync("../DevelopmentTeam/AddContact", contactRenderModel, true).Result;
            return Json(html);

        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DeleteContact(int contactId, int contactIdentifierId, int refProjectId = 0, int refProjectSiteId = 0)
        {
            var response = await _developmentTeamService.DeleteContact(contactId, contactIdentifierId, UserName, refProjectId, refProjectSiteId);
            return Json(response);
        }

        /// <summary>
        /// SaveContact
        /// </summary>
        /// <param name="renderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> SaveContact(ContactRenderModel renderModel)
        {
            renderModel.UserName = UserName;
            var response = await _developmentTeamService.SaveContact(renderModel);
            return Json(response);
        }

        #endregion
    }


}
