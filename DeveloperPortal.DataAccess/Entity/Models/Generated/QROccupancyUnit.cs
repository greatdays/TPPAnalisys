using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QROccupancyUnit
{
    public int QROccupancyUnitID { get; set; }

    public int? QuarterlyReportID { get; set; }

    public int? UnitPropSnapShotID { get; set; }

    public string? UnitNum { get; set; }

    public int? BuildingID { get; set; }

    public int? LevelID { get; set; }

    public int? SiteAddressID { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? LutPreDirCD { get; set; }

    public string? StreetName { get; set; }

    public string? LutStreetTypeCD { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? LutStateCD { get; set; }

    public string? Zip { get; set; }

    public int? LutUnitTypeID { get; set; }

    public int? LutTotalBedroomsID { get; set; }

    public int? LutTotalBathroomsID { get; set; }

    public int? LutAMIID { get; set; }

    public int? LutRentalSubsidyID { get; set; }

    public bool? IsCESUnit { get; set; }

    public bool? IsOccupied { get; set; }

    public int? PreviousProjSitePropSnapShotID { get; set; }

    public int? PreviousUnitPropSnapShotID { get; set; }

    public DateOnly? RelocationDate { get; set; }

    public bool? IsAvailabeFromAUTransferList { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public int? CurrentProjSitePropSnapShotID { get; set; }

    public bool? IsAvailableFromAUWaitList { get; set; }

    public string? AUWaitListPosition { get; set; }

    public bool? IsStartTargetedMarket { get; set; }

    public bool? IsReferralRequested { get; set; }

    public DateOnly? ReferralRequestDate { get; set; }

    public string? AgencyName { get; set; }

    public string? ReferralRecipientEmail { get; set; }

    public string? ReferralRecipientPhone { get; set; }

    public bool? IsManagersUnit { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public DateOnly? MoveInDate { get; set; }

    public DateOnly? MoveOutDate { get; set; }

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

    public string? OtherRentalSubsidy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? PreviousLiveInProperty { get; set; }

    public virtual ICollection<AssnQRRentalSubsidy> AssnQRRentalSubsidies { get; set; } = new List<AssnQRRentalSubsidy>();

    public virtual Structure? Building { get; set; }

    public virtual PropSnapshot? CurrentProjSitePropSnapShot { get; set; }

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual Level? Level { get; set; }

    public virtual LutAMI? LutAMI { get; set; }

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
