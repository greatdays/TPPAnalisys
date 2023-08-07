using DeveloperPortal.Models.Common;
using DeveloperPortal.Models.IDM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.ServiceClient
{
    public class UserServiceClient : ServiceClient
    {
        public  IConfiguration _config;
        //public UserServiceClient(IConfiguration config)
        //{
        //    _config = config;
        //}

        public UserServiceClient(IConfiguration config) : base(config) 
        {
            _config = config;
        }

        private string baseUrl;
        private string propertyBaseUrl;
        public  ApplicantSignupModel GetLookupLists_P2()
        {
            baseUrl = string.Format("{0}", new WebApiConstant(_config).GetConfigData("AAHRApiSettings:URL"));
            propertyBaseUrl = string.Format("{0}", new WebApiConstant(_config).GetConfigData("AAHRApiSettings:PropertyApiURL"));
            string requestUrl = baseUrl + WebApiConstant.GetLookupLists;

            //BaseResponse baseResponse = CreateRequest<BaseResponse>(new { }, requestUrl, ActionType.GET);
            ApplicantSignupModel signupModel = new ApplicantSignupModel(_config);
            //GetLookupLists_P2();
            
            //if (HttpStatusCode.OK == baseResponse.ResponseCode)
            //    signupModel = JsonConvert.DeserializeObject<ApplicantSignupModel>(Convert.ToString(baseResponse.Response));
            return signupModel;
        }


    }
}
