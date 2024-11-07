using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPProjectSiteSnap
{
    public int PMPProjectSiteSnapID { get; set; }

    public int PMPSnapID { get; set; }

    public int ProjectSiteID { get; set; }

    public int RefProjectSiteID { get; set; }

    public int? ProjectID { get; set; }

    public int? SiteAddressID { get; set; }

    public string? PropertyName { get; set; }

    public string? PrimaryAPN { get; set; }

    public string FileNumber { get; set; } = null!;

    public int? SiteNum { get; set; }

    public string? HIMSNumber { get; set; }

    public int? HIMSProjUniqueId { get; set; }

    public int? RegionID { get; set; }

    public int? NeighborhoodID { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public int? SourceRefID { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsCovered { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public bool? IsAccessible { get; set; }

    public bool? IsAffordable { get; set; }

    public bool? IsAccessibleAffordable { get; set; }

    public string? SiteAddress { get; set; }

    public int? LutCESTypeID { get; set; }

    public int? LutProjectSiteStatusID { get; set; }

    public int? LACountyServicePlanningAreaID { get; set; }

    /// <summary>
    /// For HACLA property
    /// </summary>
    public bool? IsTenantReferredUnit { get; set; }

    public int? ConstructionTotalSiteUnit { get; set; }

    public int? ConstructionMobilityUnit { get; set; }

    public int? ConstructionSensoryUnit { get; set; }

    public decimal? ConstructionMobilityRatio { get; set; }

    public decimal? ConstructionHVRatio { get; set; }

    public int? LutOccupancyStatusID { get; set; }

    public DateOnly? OccupancyNotificationDate { get; set; }

    public bool? IsSiteOccupiedPrior2015 { get; set; }

    public bool? IsSiteCurrentlyOccupied { get; set; }

    public string? NeighborhoodCouncil { get; set; }

    public DateOnly? ReportedFullOccupancyDate { get; set; }

    public DateOnly? PolicyCertDueDate { get; set; }

    public DateOnly? OwnershipChangeDate { get; set; }

    public bool? IsWillAUWLOpen { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutCESType? LutCESType { get; set; }

    public virtual LutOccupancyStatus? LutOccupancyStatus { get; set; }

    public virtual LutProjectSiteStatus? LutProjectSiteStatus { get; set; }

    public virtual Neighborhood? Neighborhood { get; set; }

    public virtual PMPSnap PMPSnap { get; set; } = null!;

    public virtual Project? Project { get; set; }

    public virtual ProjectSite ProjectSite { get; set; } = null!;

    public virtual SiteAddress? SiteAddressNavigation { get; set; }
}
