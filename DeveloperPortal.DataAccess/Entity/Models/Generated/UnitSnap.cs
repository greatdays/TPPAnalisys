using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class UnitSnap
{
    public int UnitSnapID { get; set; }

    public int ProjectSiteSnapID { get; set; }

    public int UnitID { get; set; }

    public int ProjectSiteID { get; set; }

    public int UnitPropSnapshotID { get; set; }

    public string? UnitNo { get; set; }

    public string? Status { get; set; }

    public string? SiteAddress { get; set; }

    public int? UnitAttributeID { get; set; }

    public int? TotalBedroomID { get; set; }

    public int? TotalBathroomID { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public int? LutUnitTypeID { get; set; }

    public int? LutAMIID { get; set; }

    public string? OtherRentalsubsidy { get; set; }

    public bool? IsCES { get; set; }

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

    public int? PreviousProjSitePropSnapShotID { get; set; }

    public int? PreviousUnitPropSnapShotID { get; set; }

    public DateOnly? RelocationDate { get; set; }

    public bool? IsAvailableFromTransferAUWaitList { get; set; }

    public int? CurrentProjSitePropSnapShotID { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

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

    public int? LutFixedFloatingUnitID { get; set; }

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
