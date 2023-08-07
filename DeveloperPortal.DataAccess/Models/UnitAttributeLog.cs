using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class UnitAttributeLog
{
    public int ListingUnitLogId { get; set; }

    public int? UnitAttributeId { get; set; }

    public int PropSnapshotId { get; set; }

    public int? LutTotalBedroomId { get; set; }

    public int? LutTotalBathroomId { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public int? LutUnitTypeId { get; set; }

    public int? LutAmiid { get; set; }

    public int? LutRentalSubsidyId { get; set; }

    public string? OtherRentalSubsidy { get; set; }

    public bool? IsCes { get; set; }

    public int? IsAddendumSigned { get; set; }

    public int? MinOccupancy { get; set; }

    public int? MaxOccupancy { get; set; }

    public decimal? MinRent { get; set; }

    public decimal? MaxRent { get; set; }

    public decimal? MinDeposit { get; set; }

    public decimal? MaxDeposit { get; set; }

    public decimal? CreditScreeningFee { get; set; }

    public double? SquareFeet { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public bool? IsAccessible { get; set; }

    public string? Attributes { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Comments { get; set; }

    public int? LutFixedFloatingUnitId { get; set; }

    public int? FloorPlanTypeId { get; set; }

    public int? LutFhatypeId { get; set; }

    public bool? Purported { get; set; }

    public bool? Certified { get; set; }

    public bool? IsConstruction { get; set; }

    public int? LutAccessibilityComplianceStatusId { get; set; }

    public bool? IsTenantReferredUnit { get; set; }

    public bool? IsAdaptable { get; set; }

    public bool? IsEnhancedAccessible { get; set; }

    public string? PreviousTenantMoved { get; set; }

    public int? PreviousProjSitePropSnapShotId { get; set; }

    public int? PreviousUnitPropSnapShotId { get; set; }

    public DateTime? RelocationDate { get; set; }

    public bool? IsAvailableFromTransferAuwaitList { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public int? CurrentProjSitePropSnapShotId { get; set; }

    public bool? IsAvailableFromAuwaitList { get; set; }

    public string? AuwaitListPosition { get; set; }

    public bool? IsStartTargetedMarket { get; set; }

    public bool? IsReferralRequested { get; set; }

    public DateTime? ReferralRequestDate { get; set; }

    public string? AgencyName { get; set; }

    public string? ReferralRecipientEmail { get; set; }

    public string? ReferralRecipientPhone { get; set; }

    public bool? IsManagersUnit { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? LutTenantSelectedFromId { get; set; }

    public string? OtherReferralSource { get; set; }

    public string? CommonCntrlPropName { get; set; }

    public string? CommonCntrlPropAddr { get; set; }

    public bool? IsOccupiedWithNeeded { get; set; }

    public bool? IsLeaseAddendumExecutedDate { get; set; }

    public DateTime? LeaseAddendumExecutedDate { get; set; }

    public bool? IsLeaseAddendumExpirationDate { get; set; }

    public DateTime? LeaseAddendumExpirationDate { get; set; }

    public bool? IsLeaseAddendumProvidedToAcHp { get; set; }

    public int? LutOccupancyReasonId { get; set; }

    public string? OtherOccupancyReason { get; set; }

    public DateTime? TenantMovedToAnotherUnitDate { get; set; }

    public int? LutLeaseAddendumNotExecuteReasonId { get; set; }

    public string? OtherLeaseAddendumNotExecuteReason { get; set; }

    public bool? CountAsMobilty { get; set; }

    public bool IsVca { get; set; }

    public bool IsCsa { get; set; }

    public DateTime? UtilizationSurveyDate { get; set; }

    public int? IsFullyAuneeded { get; set; }

    public int? TenantRequestedUnitTypeId { get; set; }

    public int? TenantRequestedBedroomsId { get; set; }

    public int? TenantRequestedBathroomsId { get; set; }

    public bool? IsAddedToAutl { get; set; }

    public string? NotAddedToAutlreason { get; set; }

    public int? IsAccessibleFeaturesNeeded { get; set; }

    public string? AccessibleFeatureType { get; set; }

    public bool? IsAdvisedRightToRm { get; set; }

    public bool? IsAddedToRarmlog { get; set; }

    public string? NotAddedToRarmlogReason { get; set; }

    public int? IsTenantHasAssistanceAnimal { get; set; }
}
