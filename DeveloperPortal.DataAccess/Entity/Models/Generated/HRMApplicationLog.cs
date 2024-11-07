using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class HRMApplicationLog
{
    public int HRMApplicationLogID { get; set; }

    public int HRMApplicationID { get; set; }

    public int ListingID { get; set; }

    public long ServiceRequestID { get; set; }

    public int LutContactTypeID { get; set; }

    public int ContactIdentifierID { get; set; }

    public string? ApplicationNumber { get; set; }

    public int? LutUnitTypeID { get; set; }

    public string? AltPhone { get; set; }

    public string? AltLutPhoneTypeCD { get; set; }

    public string? AltArea { get; set; }

    public string? AltPrefix { get; set; }

    public string? AltTrunk { get; set; }

    public int? FamilySize { get; set; }

    public decimal? IncomeHousehold { get; set; }

    public int? LutTotalBathroomsID { get; set; }

    public int? LutTotalBedroomsID { get; set; }

    public bool? MemberAgeOver55 { get; set; }

    public bool? MemberAgeOver62 { get; set; }

    public bool? IsVeteran { get; set; }

    public bool? Section8Voucher { get; set; }

    public string? ReasonableAccommodations { get; set; }

    public string? PreferContactMode { get; set; }

    public string? AltContactName { get; set; }

    public string? AltContactEmail { get; set; }

    public DateTime? SubscriptionDate { get; set; }

    public DateTime? WaitListDate { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public DateTime? UnSubscriptionDate { get; set; }

    public int? CancelReasonID { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowID { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Comment { get; set; }

    public string? AUWaitListPosition { get; set; }

    public int? LotteryResult { get; set; }

    public string? ConventionalWaitListPosition { get; set; }

    public int? HAContactIndentifierId { get; set; }

    public int? ListingSnapId { get; set; }

    public bool? IsCurrentlyHomeless { get; set; }

    public bool? IsWorriedAboutBecomingHomeless { get; set; }

    public bool? IsInUnsafeHousing { get; set; }

    public bool? NoneOfHouseholdApply { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? UnitNo { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? FullAddress { get; set; }

    public string? HMISNumber { get; set; }

    public DateTime? LogCreatedOn { get; set; }
}
