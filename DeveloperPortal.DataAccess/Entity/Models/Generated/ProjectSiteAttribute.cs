using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteAttribute
{
    public int ProjectSiteAttributeID { get; set; }

    public int PropSnapshotID { get; set; }

    public string? PropertyName { get; set; }

    public DateTime? MarketOpenDate { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public int? HousingTypeID { get; set; }

    public string? RentalInfo { get; set; }

    public string? RentalPolicy { get; set; }

    public string? RentalSpecialNotes { get; set; }

    public string? Description { get; set; }

    public string? WebSite { get; set; }

    public int? NoOfParking { get; set; }

    public decimal? ParkingFees { get; set; }

    public bool CanPurchaseMoreParking { get; set; }

    public string? ParkingComments { get; set; }

    public bool IsSharedLiving { get; set; }

    public bool IsScreeningFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public decimal? ScreeningFee { get; set; }

    public bool IsAdultFee { get; set; }

    public bool IsCreditCheck { get; set; }

    public bool IsCriminalCheck { get; set; }

    public int? YearBuilt { get; set; }

    public int? ParkingTypeID { get; set; }

    public bool IsTaxCreditProperty { get; set; }

    public string? AmmenitiesDescription { get; set; }

    public string? Attributes { get; set; }

    public string? RentalApplicationLink { get; set; }

    public DateTime? WaitListOpenDate { get; set; }

    public DateTime? WailtListCloseDate { get; set; }

    public DateTime? DocSubmitDateForOutreach { get; set; }

    public DateTime? LotteryDrawOn { get; set; }

    public DateTime? InitialOccupiedDate { get; set; }

    public int? TotalUnitsInBuilding { get; set; }

    public int? TotalMobilityUnits { get; set; }

    public int? TotalHearingUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? SeniorDesignated { get; set; }

    public bool? HasThisSiteBeenPreviouslyInspectedByAnExternalGroup { get; set; }

    public string? LUTExternalGroupId { get; set; }

    public int? MobilityUnitsPercentageRequired { get; set; }

    public int? SharedparkingLots { get; set; }

    public bool? IsParkingAvailableAtBuildingLevel { get; set; }

    public double? ResidentialParkingRatio { get; set; }

    public bool? AssignedResidentialParking { get; set; }

    public string? HearingAndVisionUnitsPercentageRequired { get; set; }

    public string? LutApplicableAccessibilityStandardId { get; set; }

    public string? LutCheckListsId { get; set; }

    public string? TTYNumber { get; set; }

    public int? LutFHAStandardId { get; set; }

    public string? LutNacRecomadationID { get; set; }

    public bool? MoveToInDevelopment { get; set; }

    public bool? IsLocked { get; set; }

    public string? LockComment { get; set; }

    public bool? MoveFromUnknownBlank { get; set; }

    public string? SelectedStatus { get; set; }

    public int? AdaptableUnitCount { get; set; }

    public bool? MoveToInDevelopmentForAffordable { get; set; }

    public bool? MoveToClosedApplicationForAffordable { get; set; }

    public bool? IsCWLOpenPriorRegistry { get; set; }

    public DateTime? CWLOpenPriorRegistryDate { get; set; }

    public string? SiteDescription { get; set; }

    public virtual ICollection<AssnPMPProjSiteAccessibleUnitFeatureSnap> AssnPMPProjSiteAccessibleUnitFeatureSnaps { get; set; } = new List<AssnPMPProjSiteAccessibleUnitFeatureSnap>();

    public virtual ICollection<AssnPMPProjTypeSiteAttrSnap> AssnPMPProjTypeSiteAttrSnaps { get; set; } = new List<AssnPMPProjTypeSiteAttrSnap>();

    public virtual ICollection<AssnPMPProjTypeSiteAttr> AssnPMPProjTypeSiteAttrs { get; set; } = new List<AssnPMPProjTypeSiteAttr>();

    public virtual ICollection<AssnProjSiteAccessibleUnitFeature> AssnProjSiteAccessibleUnitFeatures { get; set; } = new List<AssnProjSiteAccessibleUnitFeature>();

    public virtual ICollection<AssnProjectSiteQuestion> AssnProjectSiteQuestions { get; set; } = new List<AssnProjectSiteQuestion>();

    public virtual ICollection<AssnPropertyDistance> AssnPropertyDistances { get; set; } = new List<AssnPropertyDistance>();

    public virtual ICollection<AssnPropertyFeature> AssnPropertyFeatures { get; set; } = new List<AssnPropertyFeature>();

    public virtual LutHousingType? HousingType { get; set; }

    public virtual LutParkingType? ParkingType { get; set; }

    public virtual ICollection<ProjectSiteAdditionalQuestion> ProjectSiteAdditionalQuestions { get; set; } = new List<ProjectSiteAdditionalQuestion>();

    public virtual ICollection<ProjectSiteAttributeSnap> ProjectSiteAttributeSnaps { get; set; } = new List<ProjectSiteAttributeSnap>();

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;
}
