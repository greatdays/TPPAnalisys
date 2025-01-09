using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.IDM
{
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
}
