
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace DeveloperPortal.Domain.ProjectDetail
{
    public class DevelopmentTeamModel
    {
        public int ProjectSiteId { get; set; }
        public int CaseId { get; set; }
        public string APN { get; set; }
        public int ProjectId { get; set; }
        public int ContactId { get; set; }
        public int ContactIdentifierId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string TeamRole { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ContactType { get; set; }
        public string Source { get; set; }
        public string FullAddress { get; set; }
        public string Status { get; set; }
        public int AssnPropContactID { get; set; }
        public int LutContactTypeID { get; set; }
    }

    public class ContactRenderModel
    {
        public int ContactId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        public string Name { get; set; }
        public int ContactTypeId { get; set; }
        public int ContactAddressId { get; set; }
        public int OrganizationId { get; set; }
        public string Company { get; set; }
        public string Source { get; set; }

        [Required(ErrorMessage = "Please select Contact Type")]
        [Display(Name = "Contact Type")]
        public string Type { get; set; }

        [Display(Name = "House Number")]
        [Required(ErrorMessage = "Please enter House Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "House Number must be numeric")]
        public string HouseNum { get; set; }

        [Display(Name = "House Fraction Number")]
        public string HouseFracNum { get; set; }

        [Display(Name = "Street Direction")]
        public string PreDirection { get; set; }

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Please enter Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Street Type")]
        public string PostDirection { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Please enter  AddressLine1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Zip")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Zip code must be 5 characters length")]
        public string Zip { get; set; }

        public string FullAddress { get; set; }
        public string Unit { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        public bool IsMarkObsolete { get; set; }
        public string Status { get; set; }
        public bool? IsVerified { get; set; }
        public bool IsMarkedForMailing { get; set; }
        public bool IsMarkedForEmail { get; set; }
        public bool IsPrimary { get; set; }
        public int PropContactId { get; set; }
        [Display(Name = "Home Phone")]
        [RegularExpression(@"(\(?\d{3}\)?(\s|-)\d{3}\-?\d{4}(\sx(\d+_*|_{5}))?)|(\(_{3}\)\s_{3}\-_{4}\sx_{5})", ErrorMessage = "Input a valid phone number (xxx) xxx-xxxx")]
        public string PhoneHome { get; set; }
        [Display(Name = "Business Phone")]
        [Required(ErrorMessage = "Please enter Business Phone")]
        [RegularExpression(@"(\(?\d{3}\)?(\s|-)\d{3}\-?\d{4}(\sx(\d+_*|_{5}))?)|(\(_{3}\)\s_{3}\-_{4}\sx_{5})", ErrorMessage = "Input a valid phone number (xxx) xxx-xxxx")]
        public string PhoneBusiness { get; set; }
        [Display(Name = "Cell Phone")]
        [RegularExpression(@"(\(?\d{3}\)?(\s|-)\d{3}\-?\d{4}(\sx(\d+_*|_{5}))?)|(\(_{3}\)\s_{3}\-_{4}\sx_{5})", ErrorMessage = "Input a valid phone number (xxx) xxx-xxxx")]
        public string PhoneCell { get; set; }

        [Required(ErrorMessage = "Please select Contact Type")]
        public string IdentifierType { get; set; }

        public string IdentifierValue { get; set; }
        public string APN { get; set; }
        public int? StructureId { get; set; }
        public int? UnitId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedOnString { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedIn { get; set; }
        public string UserName { get; set; }
        public List<string> ContactTypeList { get; set; }
        //public List<StreetPrefixModel> StreetPrefixes { get; set; }
        //public List<StreetSuffixModel> StreetSuffixes { get; set; }
        public string AddContactType { get; set; }

        public int CaseID { get; set; } = 0;
        public int ContactIdentifierID { get; set; } = 0;
        public long ServiceRequestID { get; set; }
        public int? ProjectId { get; set; }
        public int? ProjectSiteId { get; set; }
        [Display(Name = "Contractor Type")]
        public string ContractorType { get; set; }

        public string Title { get; set; }
        public bool IsEmployee { get; set; }
        public string ContactAttribute { get; set; }
        public string ContactAddressAttribute { get; set; }
        [Display(Name = "Extension")]
        [StringLength(5, ErrorMessage = "The field Extension allows maximum length of 5.")]
        public string PhoneExtension { get; set; }
        public string PreferredContactMethod { get; set; }
        public string StreetTypeCd { get; set; }
        public bool IsContactAddress { get; set; } = true;
        public int? BirthDay { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthYear { get; set; }
        public string AltPhoneType { get; set; }
        public string AltPhoneNo { get; set; }
        public string AltPhoneExtn { get; set; }


        public bool IsAssnContactContactAdd { get; set; }
        public bool IsPoBox { get; set; }
        public bool? IsLocked { get; set; }
        public string EmployeeID { get; set; }
        public string Department { get; set; }
        public string Classification { get; set; }
        public string IDMUserName { get; set; }

        public string PrimaryTypes { get; set; }

        [Required(ErrorMessage = "Please select contact type")]
        public List<string> AssociationTypes { get; set; }
        public List<string> PrimaryAssociationTypes { get; set; }
        public bool IsRemovePropContactAssnType { get; set; } = true;

        //Alaternate contacts - AAHR Phase 2
        public string AlternateContactQuestion { get; set; }
        public string AlternateContact_FirstName { get; set; }
        public string AlternateContact_MiddleName { get; set; }
        public string AlternateContact_LastName { get; set; }
        public bool AlternateContact_Method_Email { get; set; }
        public bool AlternateContact_Method_MailingAddress { get; set; }
        public bool AlternateContact_Method_Phone { get; set; }
        public string AlternateContact_Email { get; set; }
        public string AlternateContact_PhoneType { get; set; }
        public string AlternateContact_PhoneNumber { get; set; }
        public string AlternateContact_PhoneNotification { get; set; }
        public string AlternateContact_StreetAddress { get; set; }
        public string AlternateContact_HouseNum { get; set; }
        public string AlternateContact_HouseFracNum { get; set; }
        public string AlternateContact_LutPreDirCd { get; set; }
        public string AlternateContact_StreetName { get; set; }
        public string AlternateContact_LutStreetTypeCD { get; set; }
        public string AlternateContact_ApartmentUnit { get; set; }
        public string AlternateContact_State { get; set; }
        public string AlternateContact_Zipcode { get; set; }
        public string AlternateContact_CityName { get; set; }
        public string AlternateContact_Unit { get; set; }

        // Self declaration questions - AAHR Phase 2
        public bool? IsVeteran { get; set; }
        public bool? IsCurrentlyHomeless { get; set; }
        public bool? IsWorriedAboutBecomingHomeless { get; set; }
        public bool? IsInUnsafeHousing { get; set; }
        public string AdditionalEmail { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string HMISNumber { get; set; }
        [Display(Name = "CASP Number")]
        public string CASpNumber { get; set; }
        [Display(Name = "Would you like this information to be displayed on the Registry for the public to contact? (One contact is required to be listed; the Registry will only list the latest selection.)")]
        [Required(ErrorMessage = "Please select the option.")]
        public bool? IsContactPublic { get; set; }
        public bool? NoneOfHouseholdApply { get; set; }

        public List<SelectListItem> LutStateCDList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LutPreDirCdList { get; set; }= new List<SelectListItem>();
        public List<SelectListItem> LutStreetTypeList { get; set; } = new List<SelectListItem>();
    }
}
