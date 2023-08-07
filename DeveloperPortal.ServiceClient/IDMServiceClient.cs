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
    public class IDMServiceClient
    {
        public static IConfiguration _config;

        public IDMServiceClient(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// This method is used to authenticate user while login
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public static AuthenticateResponse AuthenticateUser(User objUser, string idmApiURL)
        {
            AuthenticateResponse objAuthenticateResponse = null;

            using (HttpClient client = new HttpClient())
            {
                OperatingSystem objOperatingSystem = Environment.OSVersion;
                //HttpRequest request = HttpContext.Current.Request;
                UserSystemDetail objUserSystemDetail = new UserSystemDetail();

                objUserSystemDetail.OSName = objOperatingSystem.Platform.ToString();
                objUserSystemDetail.OSVersion = objOperatingSystem.Version.ToString();
                //objUserSystemDetail.BrowserName = request.Browser.Browser;
                //objUserSystemDetail.BrowserVersion = request.Browser.Version;

                client.BaseAddress = new Uri(idmApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                AuthenticateRequest objAuthenticateRequest = new AuthenticateRequest() { Username = objUser.UserName, Password = objUser.Password != null ? CryptoHelper.Encrypt(objUser.Password) : "", Provider = objUser.Provider, UserSystemDetail = objUserSystemDetail };
                response = client.PostAsJsonAsync(IDMServiceConstant.AuthenticateUser, objAuthenticateRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    objAuthenticateResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(result);

                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
            }
            return objAuthenticateResponse;
        }

        /// <summary>
        /// Method for validate authentication token from idm service.
        /// </summary>
        /// <param name="jwtToken">Token</param>
        /// <returns>
        /// Returns authentication response.
        /// </returns>
        public static AuthenticateResponse ValidateToken(string jwtToken, string jWTAccessCode, string sourceApp, string targetApp, string idmApiURL)
        {
            AuthenticateResponse authenticateResponse = null;

            using (HttpClient client = new HttpClient())
            {
                // request object.
                AuthenticateRequest authenticateRequest = new AuthenticateRequest()
                {
                    JWTAccessCode = jWTAccessCode,
                    JwtToken = jwtToken,
                    SourceApp = sourceApp,
                    TargetApp = targetApp
                };

                client.BaseAddress = new Uri(idmApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // get data from api.
                HttpResponseMessage response = client.PostAsJsonAsync(IDMServiceConstant.ValidateJWTToken, authenticateRequest).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    result = result.TrimStart('\"');
                    result = result.TrimEnd('\"');
                    result = result.Replace("\\", "");
                    authenticateResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(result);
                }
            }

            return authenticateResponse; // returns.
        }

        /// <summary>
        /// Method for validate authentication token from idm service.
        /// </summary>
        /// <param name="jwtToken">Token</param>
        /// <returns>
        /// Returns authentication response.
        /// </returns>
        public AuthenticateResponse ValidateToken(string jwtToken) //removed static
        {
            AuthenticateResponse authenticateResponse = null;
            

            using (HttpClient client = new HttpClient())
            {
                string idmApiURL = _config["IDMSettings:IDMPath"];
                // request object.
                AuthenticateRequest authenticateRequest = new AuthenticateRequest()
                {
                    JWTAccessCode = _config["ThisApplication:JwtAccessCode"],
                    JwtToken = jwtToken,
                    SourceApp = _config["IDMSettings:SourceApp"],
                    TargetApp = _config["IDMSettings:TargetApp"]
                };

                client.BaseAddress = new Uri(idmApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // get data from api.
                HttpResponseMessage response = client.PostAsJsonAsync(IDMServiceConstant.ValidateJWTToken, authenticateRequest).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    result = result.TrimStart('\"');
                    result = result.TrimEnd('\"');
                    result = result.Replace("\\", "");
                    authenticateResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(result);
                }
            }

            return authenticateResponse; // returns.
        }
        public static string ChangePassword(string username, string oldpassword, string newpassword, string idmApiURL, string idmAppKey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(idmApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                // var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), UserName = username, OldPassword = oldpassword, NewPassword = newpassword }; 
                var idmModel = new IDMUser() { AppKey = idmAppKey, Provider = "SQL", UserName = username, OldPassword = CryptoHelper.Encrypt(oldpassword), NewPassword = CryptoHelper.Encrypt(newpassword) };
                response = client.PostAsJsonAsync("api/UserAccount/ChangePassword", idmModel).Result;


                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    IDMUser RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
                    return RetIdmUser.Status;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return "";
            }
        }
    }

    public static class IDMServiceConstant
    {
        public const string AuthenticateUser = "api/Account/Authenticate";
        public const string ValidateJWTToken = "api/Account/ValidateJWTToken";
    }

}
