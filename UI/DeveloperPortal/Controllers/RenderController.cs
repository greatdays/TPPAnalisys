//using ComCon.DataAccess.Models.Helpers;
//using ComCon.DataAccess.ViewModel;
using DeveloperPortal.Models.Common;
using DeveloperPortal.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
//using ComCon.DataAccess.ViewModel;
using DeveloperPortal.DataAccess.Entity.Models.Helper.ComCon;
using DeveloperPortal.DataAccess.Entity.ViewModels.ComCon;
using DeveloperPortal.Models.Helper;

namespace DeveloperPortal.Controllers
{

    public class RenderController
    {
        /*
        private IConfiguration _config;
        public RenderController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public PartialViewResult RenderContact(DataAccess.Entity.ViewModel.ControlViewModel controlView, string Id = "")
        {
            string strParameters = "";
            ContactDisplayConfig contactDisplayConfig = new ContactDisplayConfig();
            if (controlView.ControlViewId == 0)
            {
                ControlViewMaster controlViewMaster = new ControlViewMaster();
                int controlviewid = Convert.ToInt32(Id);
                controlViewMaster = db.ControlViewMasters.FirstOrDefault(x => x.Id == controlviewid);
                controlView.ControlViewId = controlViewMaster.Id;
                controlView.JsonConfig = controlViewMaster.JsonConfig;

            }
            contactDisplayConfig = JsonConvert.DeserializeObject<ContactDisplayConfig>(controlView.JsonConfig);
            contactDisplayConfig.ContactDisplayConfigId = controlView.ControlViewId;
            //IDictionary<string, object> routeData = RouteData.Values;
            //NameValueCollection appSettings = System.Web.Configuration.WebConfigurationManager.AppSettings;
            ContactIdentifiersService contactIdentifiersService = new ContactIdentifiersService();
                       

            string dataFilterType = string.Join(",", contactDisplayConfig.DataFilterType);
            string dataFilterSources = string.Join(",", contactDisplayConfig.DataFilterSource);
            string strPara = string.Empty;//strParameters.Remove(0, strParameters.Trim().LastIndexOf("=") + 1);

            ServiceRequestsService serviceRequestsService = new ServiceRequestsService();
            ServiceRequestModel serviceRequestModel = new ServiceRequestModel();
            serviceRequestModel = serviceRequestsService.GetServiceRequestById(Convert.ToInt32(Id));

            if (contactDisplayConfig.ContextRefType == "Case")
            {
                strPara = Id.ToString();
            }
            else if (contactDisplayConfig.ContextRefType == "APN")
            {
                strPara = serviceRequestModel.APN;
            }
            else if (contactDisplayConfig.ContextRefType == "Project")
            {
                strPara = serviceRequestModel.RefProjectID.ToString();
            }
            else if (contactDisplayConfig.ContextRefType == "ProjectSite")
            {
                strPara = serviceRequestModel.RefProjectSiteID.ToString();
            }
            else if (contactDisplayConfig.ContextRefType == "All")
            {
                strPara = serviceRequestModel.RefProjectID.ToString();
            }

            //local code
            //string propertyBaseUrl = "http://ccris2svctest/Property.Api/";
            //BaseResponse baseResponse = CreateRequest<BaseResponse>
            //        (new { referenceId = strPara, referenceType = contactDisplayConfig.ContextRefType, source = dataFilterSources, type = dataFilterType, isHistorical = false, apn = "null" }
            //        , propertyBaseUrl + "api/ContactMgmt/GetAllContacts"
            //        , ActionType.GET);

            BaseResponse baseResponse = CreateRequest<BaseResponse>
                    (new { referenceId = strPara, referenceType = contactDisplayConfig.ContextRefType, source = dataFilterSources, type = dataFilterType, isHistorical = false, apn = "null" }
                    , AppConfig.GetConfigValue("AreaMgmtAPIURL") + "api/ContactMgmt/GetAllContacts"
                    , ActionType.GET);

            contactDisplayConfig.ContactRender = JsonConvert.DeserializeObject<List<ContactRenderModel>>(JsonConvert.SerializeObject(baseResponse.Response));

            IDMApplicationUser idmApplicationUser = new IDMApplicationUser(_config);
            foreach (ContactRenderModel item in contactDisplayConfig.ContactRender)
            {
                string fullName = idmApplicationUser.GetUserByUserName(item.ModifiedBy);
                item.ModifiedBy = fullName ?? item.ModifiedBy;
                item.ContactIdentifierID = contactIdentifiersService.GetContactByContactId(item.ContactId);
            }

            contactDisplayConfig.ContextRefId = strPara;

            if (contactDisplayConfig.ContextRefType == "Case")
            {
                contactDisplayConfig.APN = JsonConvert.DeserializeObject<string>(new ServiceRequestsService().GetAPNByCase(Convert.ToInt32(strPara)));
            }
            else if (contactDisplayConfig.ContextRefType == "APN")
            {
                contactDisplayConfig.APN = strPara;
            }
            else if (contactDisplayConfig.ContextRefType == "Structure")
            {
                BaseResponse apnResponse = CreateRequest<BaseResponse>(null, AppConfig.GetConfigValue("AreaMgmtAPIURL") + string.Format(WebApiConstant.GetAPNByStructure, strPara), ActionType.GET);
                contactDisplayConfig.APN = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(apnResponse.Response));
            }
            else if (contactDisplayConfig.ContextRefType == "Unit")
            {
                BaseResponse apnResponse = CreateRequest<BaseResponse>(null, AppConfig.GetConfigValue("AreaMgmtAPIURL") + string.Format(WebApiConstant.GetAPNByUnit, strPara), ActionType.GET);
                contactDisplayConfig.APN = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(apnResponse.Response));
            }
            else if (contactDisplayConfig.ContextRefType == "Project")
            {
                contactDisplayConfig.ProjectId = Convert.ToInt32(strPara);
                contactDisplayConfig.APN = contactDisplayConfig.ContactRender?.FirstOrDefault()?.APN;
            }
            else if (contactDisplayConfig.ContextRefType == "ProjectSite")
            {
                contactDisplayConfig.ProjectSiteId = Convert.ToInt32(strPara);
                contactDisplayConfig.APN = contactDisplayConfig.ContactRender?.FirstOrDefault()?.APN;
            }
            else if (contactDisplayConfig.ContextRefType == "All")
            {
                contactDisplayConfig.ProjectId = Convert.ToInt32(strPara);
                contactDisplayConfig.APN = contactDisplayConfig.ContactRender?.FirstOrDefault()?.APN;
            }

            // Data Filter Type
            List<string> dataFilterTypeList = new List<string>();
            List<SelectListModel> strListDFT = new List<SelectListModel>();
            dataFilterTypeList = !string.IsNullOrEmpty(dataFilterType) ? dataFilterType.Split(',').ToList() : contactDisplayConfig.GetJson("Type").Split(',').ToList();

            foreach (string item in dataFilterTypeList)
            {
                strListDFT.Add(new SelectListModel() { DisplayText = item, Value = item });
            }

            // Data Filter Source
            List<string> dataFilterSourceList = new List<string>();
            List<SelectListModel> strListDFS = new List<SelectListModel>();
            dataFilterSourceList = !string.IsNullOrEmpty(dataFilterSources) ? dataFilterSources.Split(',').ToList() : contactDisplayConfig.GetJson("Source").Split(',').ToList();

            if (dataFilterSourceList != null)
            {
                strListDFS = dataFilterSourceList.Select(item => new SelectListModel()
                {
                    DisplayText = item,
                    Value = item
                }).ToList();
            }

            contactDisplayConfig.DataFilterTypeList = strListDFT;
            contactDisplayConfig.DataFilterSourceList = strListDFS;

            return PartialView("RenderContact", contactDisplayConfig);
        }    
*/    
    }
}
