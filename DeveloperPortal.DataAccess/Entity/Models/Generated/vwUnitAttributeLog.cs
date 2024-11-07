using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwUnitAttributeLog
{
    public string? FileNumber { get; set; }

    public string? FileGroup { get; set; }

    public int? PS_ProjectId { get; set; }

    public int ProjectId { get; set; }

    public int ListingUnitLogID { get; set; }

    public int? UnitAttributeID { get; set; }

    public int PropSnapshotID { get; set; }

    public int? LutTotalBedroomID { get; set; }

    public int? LutTotalBathroomID { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public int? LutUnitTypeID { get; set; }

    public int? LutAMIID { get; set; }

    public int? LutRentalSubsidyID { get; set; }

    public string? OtherRentalSubsidy { get; set; }

    public bool? IsCES { get; set; }

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

    public int? LutFixedFloatingUnitID { get; set; }

    public int? FloorPlanTypeID { get; set; }

    public int? LutFHATypeID { get; set; }

    public bool? Purported { get; set; }

    public bool? Certified { get; set; }

    public bool? IsConstruction { get; set; }

    public int? LutAccessibilityComplianceStatusId { get; set; }

    public bool? IsTenantReferredUnit { get; set; }

    public bool? IsAdaptable { get; set; }

    public bool? IsEnhancedAccessible { get; set; }

    public string? PreviousTenantMoved { get; set; }

    public int? PreviousProjSitePropSnapShotID { get; set; }

    public int? PreviousUnitPropSnapShotID { get; set; }

    public DateOnly? RelocationDate { get; set; }

    public bool? IsAvailableFromTransferAUWaitList { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public int? CurrentProjSitePropSnapShotID { get; set; }

    public bool? IsAvailableFromAUWaitList { get; set; }

    public string? AUWaitListPosition { get; set; }

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

    public DateOnly? MovedInDate { get; set; }

    public int? LutTenantSelectedFromID { get; set; }

    public string? OtherReferralSource { get; set; }

    public string? CommonCntrlPropName { get; set; }

    public string? CommonCntrlPropAddr { get; set; }

    public bool? IsOccupiedWithNeeded { get; set; }

    public bool? IsLeaseAddendumExecutedDate { get; set; }

    public DateOnly? LeaseAddendumExecutedDate { get; set; }

    public bool? IsLeaseAddendumExpirationDate { get; set; }

    public DateOnly? LeaseAddendumExpirationDate { get; set; }

    public bool? IsLeaseAddendumProvidedToAcHP { get; set; }

    public int? LutOccupancyReasonID { get; set; }

    public string? OtherOccupancyReason { get; set; }

    public DateOnly? TenantMovedToAnotherUnitDate { get; set; }

    public int? LutLeaseAddendumNotExecuteReasonID { get; set; }

    public string? OtherLeaseAddendumNotExecuteReason { get; set; }

    public bool? CountAsMobilty { get; set; }

    public bool IsVCA { get; set; }

    public bool IsCSA { get; set; }

    public DateOnly? UtilizationSurveyDate { get; set; }

    public int? IsFullyAUNeeded { get; set; }

    public int? TenantRequestedUnitTypeID { get; set; }

    public int? TenantRequestedBedroomsID { get; set; }

    public int? TenantRequestedBathroomsID { get; set; }

    public bool? IsAddedToAUTL { get; set; }

    public string? NotAddedToAUTLReason { get; set; }

    public int? IsAccessibleFeaturesNeeded { get; set; }

    public string? AccessibleFeatureType { get; set; }

    public bool? IsAdvisedRightToRM { get; set; }

    public bool? IsAddedToRARMLog { get; set; }

    public string? NotAddedToRARMLogReason { get; set; }

    public int? IsTenantHasAssistanceAnimal { get; set; }
}
