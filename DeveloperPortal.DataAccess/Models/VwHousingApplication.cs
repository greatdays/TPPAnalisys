using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwHousingApplication
{
    public int ProjectSiteId { get; set; }

    public int ProjectSitePropertSnapshotId { get; set; }

    public string? FileNumber { get; set; }

    public string? PropertyName { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Neighborhood { get; set; }

    public string? Region { get; set; }

    public string? Cestype { get; set; }

    public string? Hrmstatus { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public DateTime? WaitListOpenDate { get; set; }

    public DateTime? WailtListCloseDate { get; set; }

    public int ApplicationCaseId { get; set; }

    public string ApplicationStatus { get; set; } = null!;

    public string? IdmuserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? FullAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? BirthMmdd { get; set; }

    public string? UnitType { get; set; }

    public string? Bedrooms { get; set; }

    public string? Bathrooms { get; set; }

    public int HrmapplicationId { get; set; }

    public int ListingId { get; set; }

    public long ServiceRequestId { get; set; }

    public int LutContactTypeId { get; set; }

    public int ContactIdentifierId { get; set; }

    public string? ContactType { get; set; }

    public string? ApplicationNumber { get; set; }

    public int? LutUnitTypeId { get; set; }

    public string? AltPhone { get; set; }

    public string? AltLutPhoneTypeCd { get; set; }

    public string? AltArea { get; set; }

    public string? AltPrefix { get; set; }

    public string? AltTrunk { get; set; }

    public int? FamilySize { get; set; }

    public decimal? IncomeHousehold { get; set; }

    public int? LutTotalBathroomsId { get; set; }

    public int? LutTotalBedroomsId { get; set; }

    public bool? MemberAgeOver55 { get; set; }

    public bool? MemberAgeOver62 { get; set; }

    public bool? IsVeteran { get; set; }

    public bool? Section8Voucher { get; set; }

    public bool? IsCurrentlyHomeless { get; set; }

    public bool? IsWorriedAboutBecomingHomeless { get; set; }

    public bool? IsInUnsafeHousing { get; set; }

    public string? ReasonableAccommodations { get; set; }

    public string? PreferContactMode { get; set; }

    public string? HousingAdvocate { get; set; }

    public string? AltContactName { get; set; }

    public string? AltContactEmail { get; set; }

    public DateTime? SubscriptionDate { get; set; }

    public DateTime? WaitListDate { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public DateTime? UnSubscriptionDate { get; set; }

    public int? CancelReasonId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Comment { get; set; }

    public int? LotteryResult { get; set; }

    public string? ConventionalWaitListPosition { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? SocialSecurityNumber { get; set; }
}
