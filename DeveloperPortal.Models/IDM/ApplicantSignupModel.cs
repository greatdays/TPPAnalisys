using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperPortal.Models.IDM
{
    internal class ApplicantSignupModel
    {
        #region YourInformation
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool SignupTermCondition { get; set; }
        #endregion

        #region ContactInformation
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public bool IsPostBox { get; set; }
        public string PostBoxNum { get; set; }
        public int? StreetNum { get; set; }
        public string StreetDir { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string StreetAddress { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        #endregion

        #region ProjectRegistration
        public List<string> Projects { get; set; }
        #endregion
    }
}
