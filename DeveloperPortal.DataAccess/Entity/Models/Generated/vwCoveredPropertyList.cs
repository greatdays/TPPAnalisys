using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwCoveredPropertyList
{
    public string? PropertyName { get; set; }

    public int? HIMSProjUniqueId { get; set; }

    public int ProjectSiteID { get; set; }

    public int RefProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public int? SiteNum { get; set; }

    public string? HIMSNumber { get; set; }

    public int? RegionID { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public int? DefaultOwnerContactID { get; set; }

    public int? NoDefaultOwner { get; set; }

    public string? OwnerContactName { get; set; }

    public string? OwnerCompanyName { get; set; }

    public string? OwnerAddress { get; set; }

    public string? OwnerEmail { get; set; }

    public string? OwnerPhone { get; set; }

    public string? OwnerHouseNum { get; set; }

    public string? OwnerHouseFracNum { get; set; }

    public string? OwnerStreet { get; set; }

    public string? OwnerUnit { get; set; }

    public string? OwnerCity { get; set; }

    public string? OwnerState { get; set; }

    public string? OwnerZip { get; set; }

    public int? DefaultPMContactID { get; set; }

    public bool? NoDefaultPM { get; set; }

    public string? PMContactName { get; set; }

    public string? PMCompanyName { get; set; }

    public string? PMAddress { get; set; }

    public string? PMEmail { get; set; }

    public string? PMPhone { get; set; }

    public string? PMHouseNum { get; set; }

    public string? PMHouseFracNum { get; set; }

    public string? PMStreet { get; set; }

    public string? PMUnit { get; set; }

    public string? PMCity { get; set; }

    public string? PMState { get; set; }

    public string? PMZip { get; set; }

    public bool? IsCoveredProperty { get; set; }

    public decimal? LAT { get; set; }

    public decimal? lon { get; set; }

    public string? ProjectName { get; set; }

    public string? typeofproject { get; set; }

    public string? HousingRegistryStatus { get; set; }

    public string PropertyCESType { get; set; } = null!;

    public string? PropertyAddress { get; set; }

    public string? AchpSiteZip { get; set; }

    public string? Neighborhood { get; set; }

    public int? NeighborhoodID { get; set; }

    public string? APN { get; set; }

    public int? TotalProjectSiteMobilityUnit { get; set; }

    public int? TotalProjectSiteSensoryUnit { get; set; }

    public int TotalProjectSiteBothMobilityHVUnit { get; set; }

    public int? TotalProjectSiteAccessibleUnit { get; set; }

    public string HasUnitData { get; set; } = null!;

    public int MobilityUnitCnt { get; set; }

    public int SensoryUnitCnt { get; set; }

    public int MobilitywHVUnitCnt { get; set; }

    public int AdaptableUnitCnt { get; set; }

    public int EnhancedSensoryUnitCnt { get; set; }

    public int? AccessibleUnitCnt { get; set; }

    public string LowestAMI { get; set; } = null!;

    public int _0Bedroom { get; set; }

    public int _1Bedroom { get; set; }

    public int _2Bedroom { get; set; }

    public int _3Bedroom { get; set; }

    public int _4orMoreBedroom { get; set; }

    public bool? LockCertifiedUnits { get; set; }

    public string? ApplicationStartDate { get; set; }

    public string? ApplicationEndDate { get; set; }

    public string? ConventionalWaitListOpenDate { get; set; }

    public string? ConventionalWaitListCloseDate { get; set; }

    public int RentalSubsidy { get; set; }

    public string? OpenForApplication { get; set; }

    public string? OpenForMarketing { get; set; }

    public string Accessibility { get; set; } = null!;

    public string RentalInformation { get; set; } = null!;

    public string Policy { get; set; } = null!;

    public string SpecialNotes { get; set; } = null!;

    public string PropertyDescription { get; set; } = null!;

    public string PropertyWebsite { get; set; } = null!;

    public int Section8 { get; set; }

    public int SpecialNeeds { get; set; }

    public decimal MaxRent { get; set; }

    public int UnverifiedComplianceCnt { get; set; }

    public int PendingCertComplianceCnt { get; set; }

    public int CertifiedComplianceCnt { get; set; }

    public string? CWLOpenPriorRegistryDate { get; set; }

    public bool? IsCWLOpenPriorRegistry { get; set; }

    public string? HousingRegistryStatusDisplayName { get; set; }
}
