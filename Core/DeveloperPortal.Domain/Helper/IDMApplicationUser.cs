//using ComCon.DataAccess.Models.IDM;
//using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.Models.IDM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace DeveloperPortal.Models.Helper
{
    public class IDMApplicationUser
    {
        private IConfiguration _config;
        public IDMApplicationUser(IConfiguration config)
        {
            _config = config;
        }
        public IDMUser ApplicantSignUp(IDMUser idmUser)
        {
            IDMUser resultIDMUser = new IDMUser();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config["IDMSettings:IDMPath"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var idmModel = new IDMUser()
                {
                    AppKey = _config["AppSettings:Application"].ToString(),// ConfigurationManager.AppSettings["IDMAppKey"].ToString(),
                    Provider = "SQL",
                    UserName = idmUser.UserName,
                    FirstName = idmUser.FirstName,
                    MiddleName = idmUser.MiddleName,
                    LastName = idmUser.LastName,
                    ContactPhone = idmUser.ContactPhone,
                    Email = idmUser.Email,
                    Password = CryptoHelper.Encrypt(idmUser.Password),
                    SecurityQuestion = string.Empty,
                    SecurityAnswer = string.Empty,
                    AppList = idmUser.AppList
                };
                HttpResponseMessage response = client.PostAsJsonAsync("api/Account/Signup_AAHR_Applicant", idmModel).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    resultIDMUser = JsonConvert.DeserializeObject<IDMUser>(result);
                }

                response.Dispose();
                response.Headers.ConnectionClose = true;

                return resultIDMUser;
            }
        }

        /// <summary>
        /// This method is used to get user details based on user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetUserByUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                /*TODO: Fix the db call - Ananth
                using (var db = new AAHREntities())
                {
                    return db.vwAspNetUsers.Where(x => x.UserName == userName)?.FirstOrDefault()?.FullName;
                }*/
            }
            return "";
        }
    }
}
