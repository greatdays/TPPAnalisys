using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteSnap
{
    public int ProjectSiteSnapId { get; set; }

    public int ListingSnapId { get; set; }

    public int ProjectSiteId { get; set; }

    public int PropSnapshotId { get; set; }

    public string? AcHpfileNumber { get; set; }

    public string? PropertyName { get; set; }

    public int? RefProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public int? RefProjectId { get; set; }

    public int? ProjectSiteAttributeId { get; set; }

    public string? PrimaryApn { get; set; }

    public int? SiteAddressId { get; set; }

    public string? SiteAddress { get; set; }

    public string? Himsnumber { get; set; }

    public int? HimsprojUniqueId { get; set; }

    public int? RegionId { get; set; }

    public int? NeighborhoodId { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public int? SourceRefId { get; set; }

    public string? Attributes { get; set; }

    public string? PropertyStatus { get; set; }

    public bool? IsCovered { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? TotalAccessibleUnits { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public int? LutCestypeId { get; set; }

    public int? HousingTypeId { get; set; }

    public string? RentalInfo { get; set; }

    public string? RentalPolicy { get; set; }

    public string? RentalSpecialNotes { get; set; }

    public string? Description { get; set; }

    public string? WebSite { get; set; }

    public string? RentalApplicationLink { get; set; }

    public int? NoOfParking { get; set; }

    public decimal? ParkingFees { get; set; }

    public bool? CanPurchaseMoreParking { get; set; }

    public string? ParkingComments { get; set; }

    public bool? IsSharedLiving { get; set; }

    public bool? IsScreeningFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public decimal? ScreeningFee { get; set; }

    public bool? IsAdultFee { get; set; }

    public bool? IsCreditCheck { get; set; }

    public bool? IsCriminalCheck { get; set; }

    public DateTime? MarketOpenDate { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public DateTime? WaitListOpenDate { get; set; }

    public DateTime? WaitListCloseDate { get; set; }

    public int? YearBuilt { get; set; }

    public int? ParkingTypeId { get; set; }

    public bool? IstaxCreditProperty { get; set; }

    public string? AmmenitiesDescription { get; set; }

    public DateOnly? OccupancyNotificationDate { get; set; }

    public bool? IsSiteOccupiedPrior2015 { get; set; }

    public bool? IsSiteCurrentlyOccupied { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CloseDateReasonByOpm { get; set; }

    public bool? IsCwlopenPriorRegistry { get; set; }

    public DateTime? CwlopenPriorRegistryDate { get; set; }

    public bool? IsWillAuwlopen { get; set; }

    public virtual ICollection<AkasiteAddressSnap> AkasiteAddressSnaps { get; set; } = new List<AkasiteAddressSnap>();

    public virtual ICollection<AssnLutDistanceTypeSnap> AssnLutDistanceTypeSnaps { get; set; } = new List<AssnLutDistanceTypeSnap>();

    public virtual ICollection<AssnProjectSiteFeatureSnap> AssnProjectSiteFeatureSnaps { get; set; } = new List<AssnProjectSiteFeatureSnap>();

    public virtual ICollection<HrmapplicationAdditionalQuestion> HrmapplicationAdditionalQuestions { get; set; } = new List<HrmapplicationAdditionalQuestion>();

    public virtual ListingSnap ListingSnap { get; set; } = null!;

    public virtual ICollection<ProjectSiteAdditionalQuestionsSnap> ProjectSiteAdditionalQuestionsSnaps { get; set; } = new List<ProjectSiteAdditionalQuestionsSnap>();

    public virtual ICollection<ProjectSiteMarketingFlyerSnap> ProjectSiteMarketingFlyerSnaps { get; set; } = new List<ProjectSiteMarketingFlyerSnap>();

    public virtual ICollection<UnitSnap> UnitSnaps { get; set; } = new List<UnitSnap>();
}
