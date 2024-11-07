using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSite
{
    public int ProjectSiteID { get; set; }

    public int RefProjectSiteID { get; set; }

    public int? ProjectID { get; set; }

    public int? SiteAddressID { get; set; }

    public string? PropertyName { get; set; }

    public string? PrimaryAPN { get; set; }

    public string? FileNumber { get; set; }

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

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

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

    public virtual ICollection<AUTransferWaitList> AUTransferWaitListCurrentUnitProjectSites { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUTransferWaitList> AUTransferWaitListMoveInProjectSites { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUWaitList> AUWaitLists { get; set; } = new List<AUWaitList>();

    public virtual ICollection<AssnProjectSiteReference> AssnProjectSiteReferences { get; set; } = new List<AssnProjectSiteReference>();

    public virtual ICollection<AssnTrainingRegistryProjectSite> AssnTrainingRegistryProjectSites { get; set; } = new List<AssnTrainingRegistryProjectSite>();

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();

    public virtual ICollection<GrievanceLog> GrievanceLogs { get; set; } = new List<GrievanceLog>();

    public virtual LACountyServicePlanningArea? LACountyServicePlanningArea { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutCESType? LutCESType { get; set; }

    public virtual LutOccupancyStatus? LutOccupancyStatus { get; set; }

    public virtual LutProjectSiteStatus? LutProjectSiteStatus { get; set; }

    public virtual Neighborhood? Neighborhood { get; set; }

    public virtual ICollection<PMPProjectSiteSnap> PMPProjectSiteSnaps { get; set; } = new List<PMPProjectSiteSnap>();

    public virtual ICollection<PMPUnitSnap> PMPUnitSnaps { get; set; } = new List<PMPUnitSnap>();

    public virtual ICollection<PhoneLog> PhoneLogs { get; set; } = new List<PhoneLog>();

    public virtual Project? Project { get; set; }

    public virtual ICollection<ProjectSiteMarketingFlyer> ProjectSiteMarketingFlyers { get; set; } = new List<ProjectSiteMarketingFlyer>();

    public virtual ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitListCurrentUnitProjectSites { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitListMoveInProjectSites { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitLists { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QREffectiveCommunication> QREffectiveCommunications { get; set; } = new List<QREffectiveCommunication>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogs { get; set; } = new List<QRGrievanceLog>();

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();

    public virtual Region? Region { get; set; }

    public virtual SiteAddress? SiteAddressNavigation { get; set; }

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
