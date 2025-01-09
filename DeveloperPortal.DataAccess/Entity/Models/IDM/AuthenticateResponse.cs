using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.IDM
{
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
        public string impersonatedFromUserName { get; set; }//set impersonatedfromUserName when user logged in as impersonated user
    }
}
