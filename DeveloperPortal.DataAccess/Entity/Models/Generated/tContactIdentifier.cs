using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class TContactIdentifier
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
}
