using ComCon.DataAccess.Models.IDM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.IDM
{
    public class ApplicantUser
    {
        public string AppKey { get; set; }
        public int IDMUserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string EmployeeTitle { get; set; }
        [Required]
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
        public string RefURL { get; set; }
    }
}
