using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ProjectSite
{
    public int ProjectSiteId { get; set; }

    public int RefProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public int? SiteAddressId { get; set; }

    public string? PropertyName { get; set; }

    public string? PrimaryApn { get; set; }

    public string? FileNumber { get; set; }

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

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

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

    public DateTime? OccupancyNotificationDate { get; set; }

    public bool? IsSiteOccupiedPrior2015 { get; set; }

    public bool? IsSiteCurrentlyOccupied { get; set; }

    public string? NeighborhoodCouncil { get; set; }

    public DateTime? ReportedFullOccupancyDate { get; set; }

    public DateTime? PolicyCertDueDate { get; set; }

    public DateTime? OwnershipChangeDate { get; set; }

    public virtual ICollection<AssnProjectSiteReference> AssnProjectSiteReferences { get; set; } = new List<AssnProjectSiteReference>();

    public virtual ICollection<AssnTrainingRegistryProjectSite> AssnTrainingRegistryProjectSites { get; set; } = new List<AssnTrainingRegistryProjectSite>();

    public virtual ICollection<AutransferWaitList> AutransferWaitListCurrentUnitProjectSites { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AutransferWaitList> AutransferWaitListMoveInProjectSites { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AuwaitList> AuwaitLists { get; set; } = new List<AuwaitList>();

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual LacountyServicePlanningArea? LacountyServicePlanningArea { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutCestype? LutCestype { get; set; }

    public virtual LutOccupancyStatus? LutOccupancyStatus { get; set; }

    public virtual LutProjectSiteStatus? LutProjectSiteStatus { get; set; }

    public virtual Neighborhood? Neighborhood { get; set; }

    public virtual ICollection<PhoneLog> PhoneLogs { get; set; } = new List<PhoneLog>();

    public virtual Project? Project { get; set; }

    public virtual ICollection<ProjectSiteMarketingFlyer> ProjectSiteMarketingFlyers { get; set; } = new List<ProjectSiteMarketingFlyer>();

    public virtual ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitListCurrentUnitProjectSites { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitListMoveInProjectSites { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitLists { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogs { get; set; } = new List<QrgrievanceLog>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();

    public virtual Region? Region { get; set; }

    public virtual SiteAddress? SiteAddressNavigation { get; set; }

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
