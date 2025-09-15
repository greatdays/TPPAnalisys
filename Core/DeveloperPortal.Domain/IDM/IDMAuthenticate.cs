using ComCon.DataAccess.ServiceClient;
using DeveloperPortal.Models.IDM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.IDM
{
    public class IDMAuthenticate
    {
        private IConfiguration _config;

        public IDMAuthenticate(IConfiguration config)
        {
            _config = config;
        }
        private string GetConfigValue(string key)
        {
            return _config[key] ?? string.Empty;
        }


        /// <summary>
        /// IDM API call to activate user
        /// </summary>
        /// <param name="ActivationCode"></param>
        /// <returns></returns>
        public IDMUser ActivateUser(string ActivationCode)
        {
            using (HttpClient client = new HttpClient())
            {
                IDMUser RetIdmUser = new IDMUser();
                //_config["AppSettings:ACTIVATION-LINK-EXPIRATION"]
                client.BaseAddress = new Uri( _config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                var idmModel = new IDMUser() { AppKey = GetConfigValue("IDMAppKey").ToString(), RegistrationActivationCode = ActivationCode };
                response = client.PostAsJsonAsync(IDMServiceConstant.ActivateUser, idmModel).Result;


                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
                    return RetIdmUser;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return RetIdmUser;
            }
        }

        public IDMUser ActivateAAHRUser(string ActivationCode)
        {
            using (HttpClient client = new HttpClient())
            {
                IDMUser RetIdmUser = new IDMUser();
                client.BaseAddress = new Uri( _config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                var idmModel = new IDMUser() { AppKey = GetConfigValue("IDMAppKey"), RegistrationActivationCode = ActivationCode };
                response = client.PostAsJsonAsync(IDMServiceConstant.ActivateAAHRUser, idmModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    RetIdmUser = JsonConvert.DeserializeObject<IDMUser>(result);
                    return RetIdmUser;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return RetIdmUser;
            }
        }

        public IDMUser UpdateIDMUserProfile(IDMUser objIDM)
        {
            IDMUser IdmUser = new IDMUser();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri( _config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                AuthResponse AuthResponse = new AuthResponse();
                int UserId = 0;
                List<string> Roles = null;
                var idmUser = new IDMUser() { AppKey = GetConfigValue("IDMAppKey"), UserName = objIDM.UserName, FirstName = objIDM.FirstName, MiddleName = objIDM.MiddleName, LastName = objIDM.LastName, Email = objIDM.Email, ContactPhone = objIDM.ContactPhone, Provider = objIDM.Provider };

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

        public string ChangePassword(string username, string oldpassword, string newpassword)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri( _config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                // var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), UserName = username, OldPassword = oldpassword, NewPassword = newpassword }; 
                var idmModel = new IDMUser() { AppKey = ConfigurationManager.AppSettings["IDMAppKey"].ToString(), Provider = "SQL", UserName = username, OldPassword = CryptoHelper.Encrypt(oldpassword), NewPassword = CryptoHelper.Encrypt(newpassword) };
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
}
