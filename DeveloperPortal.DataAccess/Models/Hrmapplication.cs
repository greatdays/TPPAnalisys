using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Hrmapplication
{
    public int HrmapplicationId { get; set; }

    public int ListingId { get; set; }

    public long ServiceRequestId { get; set; }

    public int LutContactTypeId { get; set; }

    public int ContactIdentifierId { get; set; }

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

    public string? ReasonableAccommodations { get; set; }

    public string? PreferContactMode { get; set; }

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

    public string? AuwaitListPosition { get; set; }

    public int? LotteryResult { get; set; }

    public string? ConventionalWaitListPosition { get; set; }

    public int? HacontactIndentifierId { get; set; }

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

    public string? Hmisnumber { get; set; }

    public virtual ICollection<AssnHrmapplicationPropQuestion> AssnHrmapplicationPropQuestions { get; set; } = new List<AssnHrmapplicationPropQuestion>();

    public virtual ICollection<AuwaitList> AuwaitLists { get; set; } = new List<AuwaitList>();

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual ContactIdentifier? HacontactIndentifier { get; set; }

    public virtual ICollection<HrmapplicationAdditionalQuestion> HrmapplicationAdditionalQuestions { get; set; } = new List<HrmapplicationAdditionalQuestion>();

    public virtual Listing Listing { get; set; } = null!;

    public virtual ListingSnap? ListingSnap { get; set; }

    public virtual LutContactType LutContactType { get; set; } = null!;

    public virtual LutTotalBathroom? LutTotalBathrooms { get; set; }

    public virtual LutTotalBedroom? LutTotalBedrooms { get; set; }

    public virtual LutUnitType? LutUnitType { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
