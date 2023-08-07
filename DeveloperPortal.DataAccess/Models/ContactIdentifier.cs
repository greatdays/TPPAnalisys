using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ContactIdentifier
{
    public int ContactIdentifierId { get; set; }

    public int ContactId { get; set; }

    public string? ContactType { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? ZipSuffix { get; set; }

    public string? LutPhoneTypeCd { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PhoneExt { get; set; }

    public string? PhoneHome { get; set; }

    public bool IncludeForEmail { get; set; }

    public bool IsPrimary { get; set; }

    public bool IsMailingAddress { get; set; }

    public string? LicenseNumber { get; set; }

    public string? Status { get; set; }

    public string? ServiceTrackingId { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? UnitNo { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? FullAddress { get; set; }

    public string? Salutation { get; set; }

    public string? CensoredName { get; set; }

    public string? Title { get; set; }

    public string? BusinessName { get; set; }

    public string? BusinessLicense { get; set; }

    public DateTime? LicenseValidFrom { get; set; }

    public DateTime? LicenseValidTo { get; set; }

    public string? PhoneWork { get; set; }

    public string? PhoneMobile { get; set; }

    public string? PhoneFax { get; set; }

    public string? Email2 { get; set; }

    public string? PreferredContactMethod { get; set; }

    public string? PictureThumbnail { get; set; }

    public string? PictureMain { get; set; }

    public string? IdmuserName { get; set; }

    public bool? IsReviewRequired { get; set; }

    public string? Apn { get; set; }

    public int? RefContactId { get; set; }

    public bool? IsEmployee { get; set; }

    public int? BirthDay { get; set; }

    public int? BirthMonth { get; set; }

    public int? BirthYear { get; set; }

    public string? PhoneExtension { get; set; }

    public string? MiddleName { get; set; }

    public bool? IsclarityHmissystem { get; set; }

    public string? Hmisno { get; set; }

    public bool? IsAltContact { get; set; }

    public int? AltContactReferenceId { get; set; }

    public int? AltContactReferenceSort { get; set; }

    public bool? MemberAgeOver55 { get; set; }

    public bool? MemberAgeOver62 { get; set; }

    public bool? IsVeteran { get; set; }

    public bool? IsCurrentlyHomeless { get; set; }

    public bool? IsWorriedAboutBecomingHomeless { get; set; }

    public bool? IsInUnsafeHousing { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public bool? NoneOfHouseholdApply { get; set; }

    public virtual ICollection<AssnContactContact> AssnContactContactPrimaryContacts { get; set; } = new List<AssnContactContact>();

    public virtual ICollection<AssnContactContact> AssnContactContactSecondaryContacts { get; set; } = new List<AssnContactContact>();

    public virtual ICollection<AssnOrganizationContact> AssnOrganizationContacts { get; set; } = new List<AssnOrganizationContact>();

    public virtual ICollection<AssnPropContact> AssnPropContacts { get; set; } = new List<AssnPropContact>();

    public virtual ICollection<BidPackage> BidPackages { get; set; } = new List<BidPackage>();

    public virtual ICollection<Hrmapplication> HrmapplicationContactIdentifiers { get; set; } = new List<Hrmapplication>();

    public virtual ICollection<Hrmapplication> HrmapplicationHacontactIndentifiers { get; set; } = new List<Hrmapplication>();

    public virtual LutPhoneType1? LutPhoneTypeCdNavigation { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

    public virtual LutStreetSuffix1? PostDirCdNavigation { get; set; }

    public virtual LutStreetPrefix1? PreDirCdNavigation { get; set; }

    public virtual ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();

    public virtual ICollection<ServiceRequestContact> ServiceRequestContacts { get; set; } = new List<ServiceRequestContact>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<TrainingRegistry> TrainingRegistries { get; set; } = new List<TrainingRegistry>();
}
