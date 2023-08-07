using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QroccupancyUnit
{
    public int QroccupancyUnitId { get; set; }

    public int? QuarterlyReportId { get; set; }

    public int? UnitPropSnapShotId { get; set; }

    public string? UnitNum { get; set; }

    public int? BuildingId { get; set; }

    public int? LevelId { get; set; }

    public int? SiteAddressId { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? LutPreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? LutStreetTypeCd { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? LutStateCd { get; set; }

    public string? Zip { get; set; }

    public int? LutUnitTypeId { get; set; }

    public int? LutTotalBedroomsId { get; set; }

    public int? LutTotalBathroomsId { get; set; }

    public int? LutAmiid { get; set; }

    public int? LutRentalSubsidyId { get; set; }

    public bool? IsCesunit { get; set; }

    public bool? IsOccupied { get; set; }

    public int? PreviousProjSitePropSnapShotId { get; set; }

    public int? PreviousUnitPropSnapShotId { get; set; }

    public DateTime? RelocationDate { get; set; }

    public bool? IsAvailabeFromAutransferList { get; set; }

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

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public DateTime? MoveInDate { get; set; }

    public DateTime? MoveOutDate { get; set; }

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

    public string? OtherRentalSubsidy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? PreviousLiveInProperty { get; set; }

    public virtual ICollection<AssnQrrentalSubsidy> AssnQrrentalSubsidies { get; set; } = new List<AssnQrrentalSubsidy>();

    public virtual Structure? Building { get; set; }

    public virtual PropSnapshot? CurrentProjSitePropSnapShot { get; set; }

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual Level? Level { get; set; }

    public virtual LutAmi? LutAmi { get; set; }

    public virtual LutLeaseAddendumNotExecuteReason? LutLeaseAddendumNotExecuteReason { get; set; }

    public virtual LutOccupancyReason? LutOccupancyReason { get; set; }

    public virtual LutRentalSubsidy? LutRentalSubsidy { get; set; }

    public virtual LutTenantSelectedFrom? LutTenantSelectedFrom { get; set; }

    public virtual LutTotalBathroom? LutTotalBathrooms { get; set; }

    public virtual LutTotalBedroom? LutTotalBedrooms { get; set; }

    public virtual LutUnitType? LutUnitType { get; set; }

    public virtual PropSnapshot? PreviousProjSitePropSnapShot { get; set; }

    public virtual PropSnapshot? PreviousUnitPropSnapShot { get; set; }

    public virtual QuarterlyReport? QuarterlyReport { get; set; }

    public virtual SiteAddress? SiteAddress { get; set; }

    public virtual PropSnapshot? UnitPropSnapShot { get; set; }
}
