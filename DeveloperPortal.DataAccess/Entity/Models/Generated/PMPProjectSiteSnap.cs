using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpprojectSiteSnap
{
    public int PmpprojectSiteSnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int ProjectSiteId { get; set; }

    public int RefProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public int? SiteAddressId { get; set; }

    public string? PropertyName { get; set; }

    public string? PrimaryApn { get; set; }

    public string FileNumber { get; set; } = null!;

    public int? SiteNum { get; set; }

    public string? Himsnumber { get; set; }

    public int? HimsprojUniqueId { get; set; }

    public int? RegionId { get; set; }

    public int? NeighborhoodId { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public int? SourceRefId { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsCovered { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public bool? IsAccessible { get; set; }

    public bool? IsAffordable { get; set; }

    public bool? IsAccessibleAffordable { get; set; }

    public string? SiteAddress { get; set; }

    public int? LutCestypeId { get; set; }

    public int? LutProjectSiteStatusId { get; set; }

    public int? LacountyServicePlanningAreaId { get; set; }

    /// <summary>
    /// For HACLA property
    /// </summary>
    public bool? IsTenantReferredUnit { get; set; }

    public int? ConstructionTotalSiteUnit { get; set; }

    public int? ConstructionMobilityUnit { get; set; }

    public int? ConstructionSensoryUnit { get; set; }

    public decimal? ConstructionMobilityRatio { get; set; }

    public decimal? ConstructionHvratio { get; set; }

    public int? LutOccupancyStatusId { get; set; }

    public DateOnly? OccupancyNotificationDate { get; set; }

    public bool? IsSiteOccupiedPrior2015 { get; set; }

    public bool? IsSiteCurrentlyOccupied { get; set; }

    public string? NeighborhoodCouncil { get; set; }

    public DateOnly? ReportedFullOccupancyDate { get; set; }

    public DateOnly? PolicyCertDueDate { get; set; }

    public DateOnly? OwnershipChangeDate { get; set; }

    public bool? IsWillAuwlopen { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutCestype? LutCestype { get; set; }

    public virtual LutOccupancyStatus? LutOccupancyStatus { get; set; }

    public virtual LutProjectSiteStatus? LutProjectSiteStatus { get; set; }

    public virtual Neighborhood? Neighborhood { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;

    public virtual Project? Project { get; set; }

    public virtual ProjectSite ProjectSite { get; set; } = null!;

    public virtual SiteAddress? SiteAddressNavigation { get; set; }
}
