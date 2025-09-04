using System.Net.Http.Headers;
using System.Net.Http.Json;
using DeveloperPortal.Models.IDM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DeveloperPortal.DataAccess.Entity.Models.IDM
{
    public class IDMAuthenticate
    {
       IConfiguration configuration;
        public IDMAuthenticate(IConfiguration config)
        {
        configuration = config;            
        }
        public IDMUser UpdateIDMUserProfile(IDMUser objIDM)
        {
            IDMUser IdmUser = new IDMUser();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["IDMSettings:IDMPath"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                AuthResponse AuthResponse = new AuthResponse();
                int UserId = 0;
                List<string> Roles = null;
                var idmUser = new IDMUser() { AppKey = "AAHR", UserName = objIDM.UserName, FirstName = objIDM.FirstName, MiddleName = objIDM.MiddleName, LastName = objIDM.LastName, Email = objIDM.Email, ContactPhone = objIDM.ContactPhone, Provider = objIDM.Provider };

                //if firsttime achp user then need to add AcHP authorization for this user.
                //if (Convert.ToString(HttpContext.Current.Session["AuthenticatedUserRole"]) == "NEWTOACHP")
                //{
                //    var authReq = new AuthRequest() { AppKey = AppConfig.GetConfigValue("IDMAppKey"), Username = objIDM.UserName };
                //    response = client.PostAsJsonAsync("api/AuthService/AssignAppNRolesToUser", authReq).Result;
                //    var result = response.Content.ReadAsStringAsync().Result;
                //    AuthResponse = JsonConvert.DeserializeObject<AuthResponse>(result);
                //    UserId = AuthResponse.UserId;
                //    Roles = AuthResponse.Roles;
                //    HttpContext.Current.Session["AuthenticatedUserRole"] = "";
                //}
                response = null;
                response = client.PostAsJsonAsync("api/UserAccount/UpdateUserProfile", idmUser).Result;


                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    IdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
                    //UpdateUserProfile doesnot return back the userid.
                    if (UserId > 0)
                    {
                        IdmUser.IDMUserId = UserId;

                    }
                    if (Roles != null)
                    {
                        IdmUser.Roles = Roles;
                    }
                    return IdmUser;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return IdmUser;
            }
        }
        //    #region Validate Token

        //    /// <summary>
        //    /// Method for validate authentication token from idm service.
        //    /// </summary>
        //    /// <param name="jwtToken">Token</param>
        //    /// <returns>
        //    /// Returns authentication response.
        //    /// </returns>
        //    public AuthResponse ValidateToken(string jwtToken)
        //    {
        //        AuthResponse authResponse = null;

        //        using (HttpClient client = new HttpClient())
        //        {
        //            // request object.
        //            AuthRequest authRequest = new AuthRequest()
        //            {
        //                JwtAccessCode = AppConfig.GetConfigValue("JwtAccessCode"),
        //                JwtToken = jwtToken,
        //                SourceApp = AppConfig.GetConfigValue("SourceApp"),
        //                TargetApp = AppConfig.GetConfigValue("TargetApp")
        //            };

        //            client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath"));
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            // get data from api.
        //            HttpResponseMessage response = client.PostAsJsonAsync("api/JwtToken/ProcessJWTToken", authRequest).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = response.Content.ReadAsStringAsync().Result;
        //                result = result.TrimStart('\"');
        //                result = result.TrimEnd('\"');
        //                result = result.Replace("\\", "");
        //                authResponse = new IDM.AuthResponse();
        //                authResponse = JsonConvert.DeserializeObject<AuthResponse>(result);
        //            }
        //        }

        //        return authResponse; // returns.
        //    }
        //    #endregion

        //    #region GetUserDetails API Call
        //    /// <summary>
        //    /// This method is used to get user details
        //    /// </summary>
        //    /// <returns></returns>
        //    public IDMUser GetUserDetails(IDMUser objIDM)
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            IDMUser RetIdmUser = new IDMUser();

        //            client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath").ToString());
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            HttpResponseMessage response;

        //            var idmUser = new IDMUser() { UserName = objIDM.UserName, Provider = objIDM.Provider };
        //            response = client.PostAsJsonAsync("api/Account/GetUserDetails", idmUser).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = response.Content.ReadAsStringAsync().Result;
        //                RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
        //                return RetIdmUser;
        //            }
        //            response.Dispose();
        //            response.Headers.ConnectionClose = true;
        //            return RetIdmUser;
        //        }
        //    }
        //    #endregion

        /// <summary>
        /// IDM API call to activate user
        /// </summary>
        /// <param name="ActivationCode"></param>
        /// <returns></returns>
        //public IDMUser ActivateUser(string ActivationCode)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        IDMUser RetIdmUser = new IDMUser();
        //        client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response;

        //        var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), RegistrationActivationCode = ActivationCode };
        //        response = client.PostAsJsonAsync(IDMServiceConstant.ActivateUser, idmModel).Result;


        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
        //            return RetIdmUser;
        //        }
        //        response.Dispose();
        //        response.Headers.ConnectionClose = true;
        //        return RetIdmUser;
        //    }
        //}

        //public IDMUser ActivateAAHRUser(string ActivationCode)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        IDMUser RetIdmUser = new IDMUser();
        //        client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response;

        //        var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), RegistrationActivationCode = ActivationCode };
        //        response = client.PostAsJsonAsync(IDMServiceConstant.ActivateAAHRUser, idmModel).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
        //            return RetIdmUser;
        //        }
        //        response.Dispose();
        //        response.Headers.ConnectionClose = true;
        //        return RetIdmUser;
        //    }
        //}



        //public string ChangePassword(string username, string oldpassword, string newpassword)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(AppConfig.GetConfigValue("IDMPath"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response;

        //        // var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), UserName = username, OldPassword = oldpassword, NewPassword = newpassword }; 
        //        var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), Provider = "SQL", UserName = username, OldPassword = CryptoHelper.Encrypt(oldpassword), NewPassword = CryptoHelper.Encrypt(newpassword) };
        //        response = client.PostAsJsonAsync("api/UserAccount/ChangePassword", idmModel).Result;


        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            IDMUser RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
        //            return RetIdmUser.Status;
        //        }
        //        response.Dispose();
        //        response.Headers.ConnectionClose = true;
        //        return "";
        //    }
        //}
    }
}
