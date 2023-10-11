using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.Common
{
    public class ContactIdentifierModel : AuditModel
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HouseNum { get; set; }
        public string HouseFracNum { get; set; }
        public string PreDirCd { get; set; }
        public string StreetName { get; set; }
        public string PostDirCd { get; set; }
        public string StreetTypeCd { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LutPhoneTypeCd { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string Unit { get; set; }
        public string APN { get; set; }
        public int ContactType { get; set; }
        public string ContactTypeName { get; set; }
        public long ServiceRequestID { get; set; }
        public int ContactAddressID { get; set; }
        public int ContactIdentifierID { get; set; }
        public string MailTrackingNumber { get; set; }
        public int? NoticeId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Source { get; set; }
        public string FullAddress { get; set; }
        public string ContractorType { get; set; }
        public bool IsPrimary { get; set; }
        public string PreferredContactMethod { get; set; }
        public int? BirthDay { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthYear { get; set; }
        public bool IsPoBox { get; set; }
        public bool IsActive { get; set; }

        public string Title { get; set; }
        public bool IsEmployee { get; set; }
        public string ContactAttribute { get; set; }
        public string ContactAddressAttribute { get; set; }
        public string PhoneExtension { get; set; }
        public bool IsContactAddress { get; set; } = true;
        public string EmployeeID { get; set; }
        public string Department { get; set; }
        public string Classification { get; set; }
        public string IsLocked { get; set; }
        public string AltPhoneType { get; set; }
        public string AltPhoneNo { get; set; }
        public bool IsAssnContactContactAdd { get; set; } = false;
        public bool IsMarkedForMailing { get; set; }
        public string Company { get; set; }
        public int OrganizationId { get; set; }
        public string IDMUserName { get; set; }
        public int SecondaryContactID { get; set; }
        public int? ProjectSiteID { get; set; }
        public bool IsDecline { get; set; }

        public int? ProjectId { get; set; }
        public string IdentifierValue { get; set; }
        public string IdentifierType { get; set; }
        public string PrimaryTypes { get; set; }
        public bool IsRemovePropContactAssnType { get; set; } = true;
        public List<ComCon.PropertySnapshot.Models.ContactTypeList> ContactTypeList { get; set; }
        public bool? ISClarityHMISSystem { get; set; }
        public string HMISNo { get; set; }
        public string CASpNumber { get; set; }
        public bool? IsContactPublic { get; set; }

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

        //self declaration questions
        public Nullable<bool> IsVeteran { get; set; }
        public Nullable<bool> IsCurrentlyHomeless { get; set; }
        public Nullable<bool> IsWorriedAboutBecomingHomeless { get; set; }
        public Nullable<bool> IsInUnsafeHousing { get; set; }
        public Nullable<bool> NoneOfHouseholdApply { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string AdditionalEmail { get; set; }
    }
}
