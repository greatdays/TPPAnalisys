using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.ServiceClient
{
    public class AccountServiceClient
    {
        public IConfiguration _config;
        public IHttpContextAccessor _httpContextAccessor;

        #region ValidateUsername API Call
        /// <summary>
        /// This method is used to validate username
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public ApplicantUser ValidateUsername(ApplicantUser objUser)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath"));
                client.BaseAddress = new Uri(_config["IDMSettings:IDMPath"].ToString()); 
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                var idmModel = new ApplicantUser() { UserName = objUser.UserName, Provider = objUser.Provider };
                response = client.PostAsJsonAsync("api/Account/ValidateUsername", idmModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    objUser = JsonConvert.DeserializeObject<ApplicantUser>(result);
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;
                return objUser;
            }
        }
        #endregion

        #region Authenticate API Call
        /// <summary>
        /// This method is used to authenticate user while login
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public ApplicantUser AuthenticateUser(ApplicantUser objUser)
        {  

            using (HttpClient client = new HttpClient())
            {
                OperatingSystem objOperatingSystem = Environment.OSVersion;
                //HttpRequest request = HttpContext.Current.Request;
                HttpRequest request = _httpContextAccessor.HttpContext.Request;
                UserSystemDetail objUserSystemDetail = new UserSystemDetail();

                objUserSystemDetail.OSName = objOperatingSystem.Platform.ToString();
                objUserSystemDetail.OSVersion = objOperatingSystem.Version.ToString();
                objUserSystemDetail.BrowserName = request.Headers["User-Agent"].ToString();
                //objUserSystemDetail.BrowserName = request.Browser.Browser;
                
                //TODO: find it
                //objUserSystemDetail.BrowserVersion = request.Browser.Version;

                client.BaseAddress = new Uri(_config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                AuthenticateRequest objAuthenticateRequest = new AuthenticateRequest() { Username = objUser.UserName, Password = CryptoHelper.Encrypt(objUser.Password), Provider = objUser.Provider, UserSystemDetail = objUserSystemDetail };
                response = client.PostAsJsonAsync("api/Account/AuthenticateAAHR", objAuthenticateRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    AuthenticateResponse objAuthenticateResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(result);
                    objUser.IDMUserId = objAuthenticateResponse.UserId;
                    objUser.UserName = objAuthenticateResponse.Username;
                    objUser.FullName = objAuthenticateResponse.Fullname;
                    objUser.Email = objAuthenticateResponse.Email;
                    objUser.Provider = objAuthenticateResponse.Provider;
                    objUser.LastLoginDate = objAuthenticateResponse.LastLogOn;
                    objUser.IsFirstTimeLogin = objAuthenticateResponse.IsFirstTimeLogin;
                    objUser.IsMaxUnsuccessfulAttempt = objAuthenticateResponse.IsMaxUnsuccessfulAttempt;
                    objUser.ErrorMessage = objAuthenticateResponse.ErrorMessage;
                    objUser.AppList = objAuthenticateResponse.ApplicationDetail;
                    objUser.ModifiedOn = objAuthenticateResponse.ModifiedOn;
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;
                return objUser;
            }
        }

        #endregion
    }
}
