using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQroccupancyUnit
{
    public int? ProjectSiteId { get; set; }

    public int QuarterlyReportId { get; set; }

    public string? Quarter { get; set; }

    public int? Year { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public string? Action { get; set; }

    public int QroccupancyUnitId { get; set; }

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

    public string? UnitType { get; set; }

    public string? TotalBedroom { get; set; }

    public string? TotalBathroom { get; set; }

    public string? RentalSubsidy { get; set; }

    public bool? IsCesunit { get; set; }

    public bool? IsOccupied { get; set; }

    public int? PreviousUnitPropSnapShotId { get; set; }

    public DateTime? RelocationDate { get; set; }

    public bool? IsAvailabeFromAutransferList { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public int? CurrentProjSitePropSnapShotId { get; set; }

    public bool? IsAvailableFromAuwaitList { get; set; }

    public int? AuwaitListPosition { get; set; }

    public bool? IsStartTargetedMarket { get; set; }

    public bool? IsReferralRequested { get; set; }

    public DateTime? ReferralRequestDate { get; set; }

    public string? AgencyName { get; set; }

    public string? ReferralRecipientEmail { get; set; }

    public string? ReferralRecipientPhone { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string? CurrentTenant { get; set; }

    public DateTime? MoveInDate { get; set; }

    public DateTime? MoveOutDate { get; set; }

    public string? TenantSelectedFrom { get; set; }

    public bool? IsOccupiedWithNeeded { get; set; }

    public DateTime? LeaseAddendumExecutedDate { get; set; }

    public string? OccupancyReason { get; set; }

    public string? OtherOccupancyReason { get; set; }
}
