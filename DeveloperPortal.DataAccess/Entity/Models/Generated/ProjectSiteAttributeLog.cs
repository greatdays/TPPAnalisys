using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteAttributeLog
{
    public int PropertyAttributeLogID { get; set; }

    public int? ProjectSiteAttributeID { get; set; }

    public int PropSnapshotID { get; set; }

    public string? PropertyName { get; set; }

    public string? RentalInfo { get; set; }

    public string? RentalPolicy { get; set; }

    public string? RentalSpecialNotes { get; set; }

    public string? Description { get; set; }

    public string? WebSite { get; set; }

    public int? NoOfParking { get; set; }

    public decimal? ParkingFees { get; set; }

    public bool? CanPurchaseMoreParking { get; set; }

    public string? ParkingComments { get; set; }

    public DateTime? MarketOpenDate { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? HousingTypeID { get; set; }

    public bool? IsSharedLiving { get; set; }

    public bool? IsScreeningFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public decimal? ScreeningFee { get; set; }

    public bool? IsAdultFee { get; set; }

    public bool? IsCreditCheck { get; set; }

    public bool? IsCriminalCheck { get; set; }

    public int? YearBuilt { get; set; }

    public int? ParkingTypeID { get; set; }

    public bool? IsTaxCreditProperty { get; set; }

    public string? AmmenitiesDescription { get; set; }

    public string? Attributes { get; set; }

    public string? RentalApplicationLink { get; set; }

    public DateTime? WaitListOpenDate { get; set; }

    public DateTime? WailtListCloseDate { get; set; }

    public DateTime? DocSubmitDateForOutreach { get; set; }

    public DateTime? LotteryDrawOn { get; set; }

    public DateTime? InitialOccupiedDate { get; set; }

    public int? TotalUnitsInBuilding { get; set; }

    public int? TotalMobilityUnits { get; set; }

    public int? TotalHearingUnits { get; set; }

    public string? SeniorDesignated { get; set; }

    public bool? HasThisSiteBeenPreviouslyInspectedByAnExternalGroup { get; set; }

    public string? LUTExternalGroupId { get; set; }

    public int? MobilityUnitsPercentageRequired { get; set; }

    public int? SharedparkingLots { get; set; }

    public bool? IsParkingAvailableAtBuildingLevel { get; set; }

    public double? ResidentialParkingRatio { get; set; }

    public bool? AssignedResidentialParking { get; set; }

    public string? HearingAndVisionUnitsPercentageRequired { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public string? LutCheckListsId { get; set; }

    public string? TTYNumber { get; set; }

    public int? LutFHAStandardId { get; set; }

    public string? LutNacRecomadationID { get; set; }

    public bool? IsCWLOpenPriorRegistry { get; set; }

    public DateTime? CWLOpenPriorRegistryDate { get; set; }
}
