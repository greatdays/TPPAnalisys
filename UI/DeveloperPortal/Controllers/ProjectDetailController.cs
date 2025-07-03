using ComCon.DataAccess.Models.Helpers;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
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
        private IUnitImportService _unitImportService;
        private readonly IWebHostEnvironment _env;

        public ProjectDetailController(IConfiguration configuration, IHttpContextAccessor contextAccessor, IProjectDetailService projectDetailService, IUnitImportService unitImportService, IWebHostEnvironment env)
        {
            _config = configuration;
            _contextAccessor = contextAccessor;
            _projectDetailService = projectDetailService;
            _unitImportService = unitImportService;
            _env = env;
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
}
