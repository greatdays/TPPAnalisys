using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PropertyAccountContactSnapShot1
{
    public int ID { get; set; }

    public DateTime CaptureDate { get; set; }

    public int ContactID { get; set; }

    public string? IDMUserName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public string? Company { get; set; }

    public string? Email { get; set; }

    public string? PhoneMobile { get; set; }

    public string? PhoneWork { get; set; }

    public string? PhoneHome { get; set; }

    public bool IncludeForEmail { get; set; }

    public bool IsPrimary { get; set; }

    public bool IsMailingAddress { get; set; }

    public string? Attributes { get; set; }

    public string? Source { get; set; }

    public bool IsContactDeleted { get; set; }

    public string ContactCreatedBy { get; set; } = null!;

    public DateTime ContactCreatedOn { get; set; }

    public string? ContactModifiedBy { get; set; }

    public DateTime? ContactModifiedOn { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? UnitNo { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? ZipSuffix { get; set; }

    public string? FullAddress { get; set; }

    public bool IsEmployee { get; set; }

    public int? BirthDay { get; set; }

    public int? BirthMonth { get; set; }

    public int? BirthYear { get; set; }

    public string? PhoneExtension { get; set; }
}
