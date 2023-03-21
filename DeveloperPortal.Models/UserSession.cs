using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeveloperPortal.Models
{
    public class UserSession
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LoginRole { get; set; }
        public List<string> Roles { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string UserImage { get; set; }
        public string Provider { get; set; }
        public Nullable<bool> IsFirstTimeLogin { get; set; }
        public string JWTToken { get; set; }
        public bool FromInternalApp { get; set; } // logged in from internal application
        public bool Impersonate { get; set; } // logged in as Impersonate true/false.

        public string ImpersonateUser { get; set; } // Impersonate by. 

        public DateTime? ModifiedOn { get; set; }
        public List<AppDetail> Applications { get; set; }

        /// <summary>
        /// get user session
        /// </summary>
        /// <returns>
        /// return the user session.
        /// </returns>
        public static UserSession GetUserSession(HttpContext context)
        {
            UserSession userSession = context.Session != null ? context.Session.GetObjectFromJson<UserSession>("AppUser") : new UserSession();
            if (userSession == null)
            {
                userSession = new UserSession();
                //userSession.UserName = "Guest";
            }

            return userSession; // return.
        }

        /// <summary>
        /// set user session
        /// </summary>
        /// <param name="userSession"></param>
        public static void SetUserInSession(HttpContext context, UserSession userSession)
        {
            if (userSession != null)
                context.Session.SetObjectAsJson("AppUser", userSession);
        }

        /// <summary>
        /// get value from usersession based on key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// return value from session.
        /// </returns>
        public static string GetValueFromSession(HttpContext context, string key)
        {
            string value = null;

            switch (key.ToLower())
            {
                case "userid":
                    value = GetUserSession(context).UserID.ToString();
                    break;
                case "username": /*Case added for user name */
                    value = GetUserSession(context).UserName;
                    break;
                case "role":
                    value = string.Join(",", GetUserSession(context).Roles);
                    break;
                case "jwttoken":
                    value = (GetUserSession(context).JWTToken) != null ? GetUserSession(context).JWTToken.ToString() : "";
                    break;
                default:
                    value = context.Session.GetString(key);
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
        public static UserSession AssignValues(HttpContext context, AuthenticateResponse authenticateResponse, string jwtToken, string applicationName)
        {
            if (string.IsNullOrEmpty(jwtToken))
            {
                jwtToken = authenticateResponse.ApplicationDetail?.Where(x => x.JWTToken != null).FirstOrDefault().JWTToken;
            }

            UserSession userSession = new UserSession
            {
                Roles = authenticateResponse.ApplicationDetail.Where(w => w.AppKey.Equals(applicationName)).FirstOrDefault().Roles.ToList(),
                UserID = authenticateResponse.UserId,
                UserName = authenticateResponse.Username,
                FullName = authenticateResponse.Fullname,
                Email = authenticateResponse.Email,
                Provider = authenticateResponse.Provider,
                LastLoginDate = authenticateResponse.LastLogOn,
                IsFirstTimeLogin = authenticateResponse.IsFirstTimeLogin,
                JWTToken = jwtToken,
                ModifiedOn = authenticateResponse.ModifiedOn,
                FromInternalApp = true,
                Impersonate = null != context.Request.GetTypedHeaders().Referer ? (context.Request.GetTypedHeaders().Referer.ToString().Contains("RefNoSearch") ? true : false) : false,
                ImpersonateUser = null != context.Request.GetTypedHeaders().Referer ? (context.Request.GetTypedHeaders().Referer.ToString().Contains("RefNoSearch") ? HttpUtility.ParseQueryString(context.Request.GetTypedHeaders().Referer.Query)["UserName"] : "") : "",
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
                                    }).ToList()
            };

            return userSession; // return.
        }
    }


    public class AuthResponse
    {
        public string AppKey { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool? IsFirstTimeLogin { get; set; }
        public Nullable<bool> IsLocked { get; set; } // Check If Account is locked.
        public bool IsMaxUnsuccessfulAttempt { get; set; } // Check if last unsuccessful log-in attempts
        public List<string> Roles { get; set; }
        public string ErrorMessage { get; set; }
        public int UserId { get; set; }
        public string LogonData { get; set; }
        public string Provider { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime LastLogOn { get; set; }
        public string JWTToken { get; set; } // Set during authentication
        public List<AppDetail> Applications { get; set; }
        public List<ApplicationDetail> ApplicationDetail { get; set; }
        public List<AppRoles> DeptAccess { get; set; } // Access to all application(s) in the department
    }

    public class AppDetail
    {
        public int ApplicationId { get; set; }
        public string AppKey { get; set; }
        public string AppName { get; set; }
        public string ApplicationURL { get; set; }
        public string JWTAccessCode { get; set; }
        public string JWTToken { get; set; }
        public List<string> Roles { get; set; }
        public string ConnectionString { get; set; }
        public string Attributes { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAppAssociated { get; set; }
    }

    [Serializable]
    public class AppRoles
    {
        public string AppKey { get; set; }
        public List<string> Roles { get; set; }
    }

    /// <summary>
    /// ApplicationDetail class
    /// </summary>
    public class ApplicationDetail
    {
        public int ApplicationId { get; set; }
        public string AppKey { get; set; }
        public string AppName { get; set; }
        public string ApplicationURL { get; set; }
        public string JWTAccessCode { get; set; }
        public string JWTToken { get; set; }
        public List<string> Roles { get; set; }
        public string ConnectionString { get; set; }
        public string Attributes { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAppAssociated { get; set; }
    }

    /// <summary>
    /// AuthenticateResponse class
    /// </summary>
    public class AuthenticateResponse
    {
        public string AppKey { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool isAuthenticated { get; set; }
        public bool? IsFirstTimeLogin { get; set; }
        public Nullable<bool> IsLocked { get; set; } = false;// Check If Account is locked.
        public bool IsMaxUnsuccessfulAttempt { get; set; } = false;// Check if last unsuccessful log-in attempts
        public string ErrorMessage { get; set; }
        public int UserId { get; set; }
        public string Provider { get; set; }
        public DateTime LastLogOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public List<ApplicationDetail> ApplicationDetail { get; set; }
        public string JWTToken { get; set; } // Set during authentication
        public UserSystemDetail UserSystemDetail { get; set; }
        public bool IsAppAssociated { get; set; }
    }

    /// <summary>
    /// User system details
    /// </summary>
    public class UserSystemDetail
    {
        public string OSName { get; set; }
        public string OSVersion { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }

    #region User class
    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        public string AppKey { get; set; }
        public int IDMUserId { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmployeeTitle { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string ErrorMessage { get; set; }
        public string NewPassword { get; set; }
        public string RegistrationActivationCode { get; set; }
        public string AccountReason { get; set; }
        public string ContactPhone { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsFirstTimeLogin { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public List<UserContactDetail> ContactList { get; set; }
        public UserProfileDetail ExtendedUserProfile { get; set; }
        public List<ApplicationDetail> AppList { get; set; }
        public bool IsMaxUnsuccessfulAttempt { get; set; } = false;// Check if last unsuccessful log-in attempts
    }
    #endregion

    #region UserContactDetail class
    /// <summary>
    /// UserContactDetail class
    /// </summary>
    public class UserContactDetail
    {
        public Nullable<int> ContactTypeId { get; set; }
        public string ContactNumber { get; set; }
    }
    #endregion

    #region UserProfileDetail class
    /// <summary>
    /// UserProfileDetail class
    /// </summary>
    public class UserProfileDetail
    {
        public string WorkPhone { get; set; }
        public string PrimaryHomePhone { get; set; }
        public string SecondaryHomePhone { get; set; }
        public string PrimaryCellPhone { get; set; }
        public string SignatureFile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool? SendEStatement { get; set; }
        public bool? Notification { get; set; }
        public string Company { get; set; }
    }
    #endregion

    /// <summary>
    /// AuthenticateRequest class
    /// </summary>
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Provider { get; set; }
        public string Password { get; set; }
        public string JWTAccessCode { get; set; }
        public string JwtToken { get; set; }      // Token contains the Appkey in Claim data
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsFirstTimeLogin { get; set; }
        public string SourceApp { get; set; } //Used in security token exchange between application; This may not be IDM systems AppKey
        public string TargetApp { get; set; } //Used in security token exchange between application; This may not be IDM systems AppKey
        public UserSystemDetail UserSystemDetail { get; set; }
    }

    public class IDMUser
    {
        public string AppKey { get; set; }
        public int IDMUserId { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Division { get; set; }
        public string Section { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string EmployeeTitle { get; set; }
        public List<string> Roles { get; set; }
        public string TempEmployeeNumber { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public Dictionary<string, string> SecurityQuestionAnswer { get; set; }
        public string ErrorMessage { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ActivationURL { get; set; }
        public string RegistrationActivationCode { get; set; }
        public string TemporaryPassword { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Nullable<bool> IsFirstTimeLogin { get; set; }
        public Nullable<bool> IsActive { get; set; }
        //public List<ContactDetail> ContactList { get; set; }
        public Nullable<bool> IsLocked { get; set; } // Check If Account is locked.
        public bool IsMaxUnsuccessfulAttempt { get; set; } // Check if last unsuccessful log-in attempts
        //public UserProfile ExtendedUserProfile { get; set; }
        public string JWTToken { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public List<AppDetail> AppList { get; set; }
    }
}
