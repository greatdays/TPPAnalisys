using DeveloperPortal.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DeveloperPortal.ServiceClient;
using DeveloperPortal.Models.IDM;
using UserSession = DeveloperPortal.Models.IDM.UserSession;
using ComCon.DataAccess.Models.Helpers;

namespace DeveloperPortal.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _config;
        // Here we are using Dependency Injection to inject the Configuration object
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Login based on AppSetting 'AuthenticationMode'
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tabname"></param>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public ActionResult Login(string userName = null, string tabname = null, string jwtToken = null)
        {
            UserSession userSession = UserSession.GetUserSession(HttpContext);
            if (string.IsNullOrEmpty(userSession.UserName))
            {
                return UserLogin(userName, tabname);
            }
            return RedirectToAction("GetProjectData", "Dashboard");
        }


        #region Login for windows authetication
        /// <summary>
        ///  User login for windows authetication
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult UserLogin(string UserName = null, string tabname = null)
        {
            /* Get Logon User */
            if (string.IsNullOrEmpty(UserName)) // UserName is null or empty only on LIVE MODE
            {
                UserName = GetLogonUser();
            }

            string applicationName = _config["ThisApplication:Application"].ToString();
            string applicationURL = _config["ThisApplication:ApplicationURL"].ToString();

            if (!string.IsNullOrEmpty(UserName))
            {
                User objUser = new User
                {
                    UserName = UserName,
                    Provider = "Active Directory"
                };
                string idmApiURL = _config["IDMSettings:IDMPath"].ToString();
                AuthenticateResponse authenticateResponse = IDMServiceClient.AuthenticateUser(objUser, idmApiURL);

                if ((null != authenticateResponse) && (authenticateResponse.UserId > 0))
                {
                    var userDetail = authenticateResponse.ApplicationDetail.FirstOrDefault(a => a.AppKey.Equals(applicationName));
                    if (userDetail != null)
                    {
                        //Create the identity for the user  
                        var identity = new ClaimsIdentity(new[] {
                                        new Claim(ClaimTypes.Name, authenticateResponse.Username),
                                        new Claim(ClaimTypes.Role,string.Join(",", userDetail.Roles))
                                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        UserSession.SetUserInSession(HttpContext, UserSession.AssignValues(HttpContext, authenticateResponse, null, applicationName));

                        return RedirectToAction("GetProjectData", "Dashboard");
                    }
                }
            }

            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
        }
        #endregion

        /// <summary>
        /// authenticate idm user based on token.
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <param name="tabname"></param>
        /// <returns>
        /// Redirect to landing page if authentication success.
        /// </returns>
        public ActionResult ValidateToken(string jwtToken, string tabname)
        {
            UserSession userSession = UserSession.GetUserSession(HttpContext);

            string applicationName = _config["ThisApplication:Application"].ToString();
            string applicationURL = _config["ThisApplication:ApplicationURL"].ToString();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                //Common.Common.SetSession("JWTToken", jwtToken);
                // authenticate user token from api.             
                AuthenticateResponse authenticateResponse = IDMServiceClient.ValidateToken(jwtToken,
                    _config["ThisApplication:JwtAccessCode"].ToString(),
                    _config["IDMSettings:SourceApp"].ToString(),
                    _config["IDMSettings:TargetApp"].ToString(),
                    _config["IDMSettings:IDMPath"].ToString());

                if ((null != authenticateResponse) && (authenticateResponse.UserId > 0))
                {
                    var userDetail = authenticateResponse.ApplicationDetail.FirstOrDefault(a => a.AppKey.Equals(applicationName));
                    if (userDetail != null)
                    {
                        //Create the identity for the user  
                        var identity = new ClaimsIdentity(new[] {
                                        new Claim(ClaimTypes.Name, authenticateResponse.Username),
                                        new Claim(ClaimTypes.Role,string.Join(",", userDetail.Roles))
                                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        UserSession.SetUserInSession(HttpContext, UserSession.AssignValues(HttpContext, authenticateResponse, null, applicationName));

                        return RedirectToAction("GetProjectData", "Dashboard");
                    }
                }
            }
            else if (null != HttpContext.Session && null != userSession && userSession.UserID > 0)
            {
                return RedirectToAction("Login", "Home");
            }

            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
        }

        /// <summary>
        /// Action for log off from application.
        /// </summary>
        /// <returns>
        /// Returns to login view.
        /// </returns>
        public ActionResult LogOff()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            string applicationURL = _config["ThisApplication:ApplicationURL"].ToString();

            return Redirect($"{_config["IDMSettings:CentralIDMURL"]}&returnUrl={applicationURL}");
        }

        #region Authenticate Windows User
        /* Function To Authenticate Windows User */
        /// <summary>
        ///  Get log on user for windows authetication
        /// </summary>
        /// <returns></returns>
        public string GetLogonUser()
        {
            /*Get Windows User Name*/
            System.Security.Principal.IIdentity id = HttpContext.User.Identity;
            string UserName = id.Name;
            if (id.IsAuthenticated)
            {
                int startIdx;
                if ((startIdx = UserName.IndexOf(@"\")) > 0)
                {
                    UserName = UserName.Substring(startIdx + 1);
                }
            }
            return UserName;
        }
        #endregion

        [HttpGet]
        [Authorize]
        public ActionResult MyAccount()
        {
            return View();
        }


        #region "Change Password"

        /// <summary>
        /// GET : Change Password
        /// </summary>
        /// <returns>Change Password</returns>
        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            ChangePasswordModel changepasswordModel = new ChangePasswordModel();
            changepasswordModel.UserName = UserSession.GetUserSession(HttpContext).UserName == null ? "" : UserSession.GetUserSession(HttpContext).UserName;
            return PartialView(changepasswordModel);
        }

        /// <summary>
        /// POST : Change Password
        /// </summary>
        /// <returns>Change Password</returns>
        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel changepasswordModel)
        {
            JsonData<JsonStatus> data = new JsonData<JsonStatus>(new JsonStatus());

            if (ModelState.IsValid)
            {
                string Status = IDMServiceClient.ChangePassword(changepasswordModel.UserName, changepasswordModel.CurrentPassword, changepasswordModel.NewPassword, _config["IDMSettings:IDMPath"].ToString(), _config["ThisApplication:AppKey"].ToString());
                if (Status == null || Status != "")
                {
                    if (Status.Contains("IDM106"))
                    {
                        data.Result.Status = false;
                    }
                    else
                    {
                        data.Result.Status = true;
                    }
                }
                else
                {
                    data.Result.Status = false;
                }
                data.Result.Data = new { ErrorMsg = Status };
                ModelState.Clear();
            }
            return Json(data);
        }
        #endregion
    }
}
