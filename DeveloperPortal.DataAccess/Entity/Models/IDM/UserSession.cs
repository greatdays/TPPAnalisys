using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SymmetricKeyGenTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeveloperPortal.DataAccess.Entity.Models.IDM
{
    internal class UserSession
    {
        public IHttpContextAccessor _httpContextAccessor;
        public UserSession(IHttpContextAccessor httpConfig)
        {
            _httpContextAccessor = httpConfig;
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LoginRole { get; set; }
        public List<string> Roles { get; set; }
        public DateTime LastLoginDate { get; set; }


        public DateTime LastNewsViewDate { get; set; }

        public string UserImage { get; set; }
        public string Provider { get; set; }
        public Nullable<bool> IsFirstTimeLogin { get; set; }
        public string JWTToken { get; set; }
        public bool FromInternalApp { get; set; } // logged in from internal application
        public bool Impersonate { get; set; } // logged in as Impersonate true/false.

        public string ImpersonateUser { get; set; } // Impersonate by. 

        public DateTime? ModifiedOn { get; set; }
        public List<AppDetail> Applications { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string impersonatedFromUserName { get; set; }//set impersonatedfromUserName when user logged in as impersonated user
        /// <summary>
        /// get user session
        /// </summary>
        /// <returns>
        /// return the user session.
        /// </returns>
        public UserSession GetUserSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            byte[] sessionBytes;
            UserSession? userSession = null;
            if (session == null)
            {
                userSession = new UserSession(_httpContextAccessor);
            }
            else {
                if(session.TryGetValue("AppUser", out sessionBytes))
                {
                    string result = Encoding.UTF8.GetString(sessionBytes);
                    userSession = JsonConvert.DeserializeObject<UserSession>(result);
                }
            }
            
            //UserSession userSession = HttpContext.Current != null && HttpContext.Current.Session != null ? HttpContext.Current.Session["AppUser"] as UserSession : new UserSession();
            if (userSession == null)
            {
                //userSession = new UserSession();
                userSession = new UserSession(_httpContextAccessor);
                //userSession.UserName = "Guest";
            }

            return userSession; // return.
        }

        /// <summary>
        /// get user session for header.
        /// </summary>
        /// <returns>
        /// return the user session json string.
        /// </returns>
        public string GetUserSessionJson()
        {
            //UserSession userSession = null != HttpContext.Current && null != HttpContext.Current.Session ? HttpContext.Current.Session["AppUser"] as UserSession : new UserSession();

            var session = _httpContextAccessor.HttpContext?.Session;
            byte[] sessionBytes;
            UserSession? userSession = null;
            if (session == null)
            {
                userSession = new UserSession(_httpContextAccessor);
            }
            else
            {
                if (session.TryGetValue("AppUser", out sessionBytes))
                {
                    string result = Encoding.UTF8.GetString(sessionBytes);
                    userSession = JsonConvert.DeserializeObject<UserSession>(result);
                }
            }

            if (userSession == null)
            {
                //userSession = new UserSession();
                userSession = new UserSession(_httpContextAccessor);
                // convert to json string and encrypt it.
                string loginUserJson = JsonConvert.SerializeObject(userSession);
                return CryptoHelper.Encrypt(loginUserJson); // return.
            }
            else
            {
                //UserSession loginSession = new UserSession();
                UserSession loginSession = new UserSession(_httpContextAccessor);
                loginSession.Provider = userSession.Provider;
                loginSession.FullName = userSession.FullName;
                loginSession.UserID = userSession.UserID;
                loginSession.UserName = userSession.UserName;
                loginSession.impersonatedFromUserName = userSession.UserName;
                loginSession.JWTToken = userSession.JWTToken;
                // convert to json string and encrypt it.
                string loginUserJson = JsonConvert.SerializeObject(userSession);

                return CryptoHelper.Encrypt(loginUserJson); // return.
            }
        }

        /// <summary>
        /// set user session
        /// </summary>
        /// <param name="userSession"></param>
        public void SetUserInSession(UserSession userSession)
        {
            if (userSession != null)
            {
                //HttpContext.Current.Session["AppUser"] = userSession;
                //HttpContext.Current.Session["AuthenticateUser"] = userSession.UserID;

                var session = _httpContextAccessor.HttpContext?.Session;
                string serializedObj = JsonConvert.SerializeObject(userSession);
                byte[] result = Encoding.UTF8.GetBytes(serializedObj);

                if (session != null)
                {
                    session.Set("AppUser", result);

                    result = BitConverter.GetBytes(userSession.UserID);
                    session.Set("AppUser", result); 
                }
            }
        }

        /// <summary>
        /// get value from usersession based on key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// return value from session.
        /// </returns>
        public string GetValueFromSession(string key)
        {
            string value = null;

            switch (key.ToLower())
            {
                case "userid":
                    value = GetUserSession().UserID.ToString();
                    break;
                case "username": /*Case added for user name */
                    value = GetUserSession().UserName;
                    break;
                case "role":
                    value = string.Join(",", GetUserSession().Roles);
                    break;
                case "jwttoken":
                    value = (GetUserSession().JWTToken) != null ? GetUserSession().JWTToken.ToString() : "";
                    break;
                case "fullname": /* Case added for User Fullname*/
                    value = GetUserSession().FullName.ToString();
                    break;
                default:
                    //value = (string)HttpContext.Current.Session[key];
                    var session = _httpContextAccessor.HttpContext?.Session;
                    if (session != null)
                    {
                        session.GetString(key);
                    }
                    break;
            }

            return value;
        }

        /// <summary>
        /// assign values to user session class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authenticateResponse"></param>
        /// <param name="jwtToken"></param>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        public static UserSession AssignValues(ControllerContext context, AuthenticateResponse authenticateResponse, string jwtToken, string applicationName)
        {
            if (string.IsNullOrEmpty(jwtToken))
            {
                jwtToken = authenticateResponse.ApplicationDetail?.Where(x => x.JWTToken != null).FirstOrDefault().JWTToken;
            }
            IHttpContextAccessor httpContextAccessor = (IHttpContextAccessor)(context.HttpContext?.Session);
            UserSession userSession = new UserSession(httpContextAccessor);

            userSession.Roles = authenticateResponse.ApplicationDetail.Where(w => w.AppKey.Equals(applicationName)).FirstOrDefault().Roles.ToList();
            userSession.UserID = authenticateResponse.UserId;
            userSession.UserName = authenticateResponse.Username;
            userSession.FullName = authenticateResponse.Fullname;
            userSession.Email = authenticateResponse.Email;
            userSession.Provider = authenticateResponse.Provider;
            userSession.LastLoginDate = authenticateResponse.LastLogOn;
            userSession.LastNewsViewDate = DateTime.MinValue;
            userSession.IsFirstTimeLogin = authenticateResponse.IsFirstTimeLogin;
            userSession.JWTToken = jwtToken;
            userSession.ModifiedOn = authenticateResponse.ModifiedOn;
            userSession.FromInternalApp = true;
            var referrer = context.HttpContext.Request.Headers["Referer"];
            string urlReferrer = string.Empty;
            string query = string.Empty;
            if (!string.IsNullOrEmpty(referrer))
            {
                urlReferrer = referrer.ToString();
                var uri = new Uri(urlReferrer);
                query = uri.Query;
            }
            userSession.Impersonate = null != urlReferrer ? (urlReferrer.Contains("RefNoSearch") ? true : false) : false;
            userSession.ImpersonateUser = null != urlReferrer ? (urlReferrer.Contains("RefNoSearch") ? HttpUtility.ParseQueryString(query)["UserName"] : string.Empty) : string.Empty;

            //userSession.Impersonate = null != context.HttpContext.Request.UrlReferrer ? (context.HttpContext.Request.UrlReferrer.ToString().Contains("RefNoSearch") ? true : false) : false;
            //userSession.ImpersonateUser = null != context.HttpContext.Request.UrlReferrer ? (context.HttpContext.Request.UrlReferrer.ToString().Contains("RefNoSearch") ? HttpUtility.ParseQueryString(context.HttpContext.Request.UrlReferrer.Query)["UserName"] : "") : "";
            userSession.Applications = authenticateResponse.ApplicationDetail?
                                    .Select(x => new AppDetail
                                    {
                                        ApplicationId = x.ApplicationId,
                                        AppKey = x.AppKey,
                                        AppName = x.AppName,
                                        ApplicationURL = x.ApplicationURL,
                                        JWTAccessCode = x.JWTAccessCode,
                                        JWTToken = x.JWTToken,
                                        Roles = x.Roles,
                                        IsLocked = x.IsLocked,
                                        Attributes = x.Attributes,
                                        IsAppAssociated = x.IsAppAssociated
                                    }).ToList();
                userSession.FirstName = authenticateResponse.Firstname;
                userSession.LastName = authenticateResponse.Lastname;
            userSession.impersonatedFromUserName = authenticateResponse.impersonatedFromUserName;//set impersonatedfromUserName when user logged in as impersonated user

            /*UserSession userSession = new UserSession
            {                
                Roles = authenticateResponse.ApplicationDetail.Where(w => w.AppKey.Equals(applicationName)).FirstOrDefault().Roles.ToList(),
                UserID = authenticateResponse.UserId,
                UserName = authenticateResponse.Username,
                FullName = authenticateResponse.Fullname,
                Email = authenticateResponse.Email,
                Provider = authenticateResponse.Provider,
                LastLoginDate = authenticateResponse.LastLogOn,
                LastNewsViewDate = DateTime.MinValue,
                IsFirstTimeLogin = authenticateResponse.IsFirstTimeLogin,
                JWTToken = jwtToken,
                ModifiedOn = authenticateResponse.ModifiedOn,
                FromInternalApp = true,
                Impersonate = null != context.HttpContext.Request.UrlReferrer ? (context.HttpContext.Request.UrlReferrer.ToString().Contains("RefNoSearch") ? true : false) : false,
                ImpersonateUser = null != context.HttpContext.Request.UrlReferrer ? (context.HttpContext.Request.UrlReferrer.ToString().Contains("RefNoSearch") ? HttpUtility.ParseQueryString(context.HttpContext.Request.UrlReferrer.Query)["UserName"] : "") : "",
                Applications = authenticateResponse.ApplicationDetail?
                                    .Select(x => new AppDetail
                                    {
                                        ApplicationId = x.ApplicationId,
                                        AppKey = x.AppKey,
                                        AppName = x.AppName,
                                        ApplicationURL = x.ApplicationURL,
                                        JWTAccessCode = x.JWTAccessCode,
                                        JWTToken = x.JWTToken,
                                        Roles = x.Roles,
                                        IsLocked = x.IsLocked,
                                        Attributes = x.Attributes,
                                        IsAppAssociated = x.IsAppAssociated
                                    }).ToList(),
                FirstName = authenticateResponse.Firstname,
                LastName = authenticateResponse.Lastname,
                impersonatedFromUserName = authenticateResponse.impersonatedFromUserName//set impersonatedfromUserName when user logged in as impersonated user

            };*/

            return userSession; // return.
        }
    }
}
