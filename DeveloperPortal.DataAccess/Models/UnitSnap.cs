using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class UnitSnap
{
    public int UnitSnapId { get; set; }

    public int ProjectSiteSnapId { get; set; }

    public int UnitId { get; set; }

    public int ProjectSiteId { get; set; }

    public int UnitPropSnapshotId { get; set; }

    public string? UnitNo { get; set; }

    public string? Status { get; set; }

    public string? SiteAddress { get; set; }

    public int? UnitAttributeId { get; set; }

    public int? TotalBedroomId { get; set; }

    public int? TotalBathroomId { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public int? LutUnitTypeId { get; set; }

    public int? LutAmiid { get; set; }

    public string? OtherRentalsubsidy { get; set; }

    public bool? IsCes { get; set; }

    public int? IsAddendumSigned { get; set; }

    public bool? IsAccessible { get; set; }

    public int? MinOccupancy { get; set; }

    public int? MaxOccupancy { get; set; }

    public decimal? MinRent { get; set; }

    public decimal? MaxRent { get; set; }

    public decimal? MinDeposit { get; set; }

    public decimal? MaxDeposit { get; set; }

    public decimal? CreditScreeningFee { get; set; }

    public double? SquareFeet { get; set; }

    public bool? IsTenantReferredUnit { get; set; }

    public string? PreviousTenantMoved { get; set; }

    public int? PreviousProjSitePropSnapShotId { get; set; }

    public int? PreviousUnitPropSnapShotId { get; set; }

    public DateTime? RelocationDate { get; set; }

    public bool? IsAvailableFromTransferAuwaitList { get; set; }

    public int? CurrentProjSitePropSnapShotId { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

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

    public int? LutFixedFloatingUnitId { get; set; }

    public int? LutAccessibilityComplianceStatusId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnRentalSubsidySnap> AssnRentalSubsidySnaps { get; set; } = new List<AssnRentalSubsidySnap>();

    public virtual ICollection<AssnUnitFeatureSnap> AssnUnitFeatureSnaps { get; set; } = new List<AssnUnitFeatureSnap>();

    public virtual LutLeaseAddendumNotExecuteReason? LutLeaseAddendumNotExecuteReason { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
