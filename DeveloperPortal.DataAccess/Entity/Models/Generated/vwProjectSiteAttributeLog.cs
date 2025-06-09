using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwProjectSiteAttributeLog
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public int? PsProjectId { get; set; }

    public string? PsFileNumber { get; set; }

    public string? PsHimsnumber { get; set; }

    public string? PsPrimaryApn { get; set; }

    public string? PsSiteAddress { get; set; }

    public int PropertyAttributeLogId { get; set; }

    public int? ProjectSiteAttributeId { get; set; }

    public int PropSnapshotId { get; set; }

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

    public int? HousingTypeId { get; set; }

    public bool? IsSharedLiving { get; set; }

    public bool? IsScreeningFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public decimal? ScreeningFee { get; set; }

    public bool? IsAdultFee { get; set; }

    public bool? IsCreditCheck { get; set; }

    public bool? IsCriminalCheck { get; set; }

    public int? YearBuilt { get; set; }

    public int? ParkingTypeId { get; set; }

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

    public string? LutexternalGroupId { get; set; }

    public int? MobilityUnitsPercentageRequired { get; set; }

    public int? SharedparkingLots { get; set; }

    public bool? IsParkingAvailableAtBuildingLevel { get; set; }

    public double? ResidentialParkingRatio { get; set; }

    public bool? AssignedResidentialParking { get; set; }

    public string? HearingAndVisionUnitsPercentageRequired { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public string? LutCheckListsId { get; set; }

    public string? Ttynumber { get; set; }

    public int? LutFhastandardId { get; set; }

    public string? LutNacRecomadationId { get; set; }

    public bool? IsCwlopenPriorRegistry { get; set; }

    public DateTime? CwlopenPriorRegistryDate { get; set; }
}
