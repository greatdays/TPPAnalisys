using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwCoveredPropertyList
{
    public string? PropertyName { get; set; }

    public int ProjectSiteId { get; set; }

    public int RefProjectSiteId { get; set; }

    public string? FileNumber { get; set; }

    public int? SiteNum { get; set; }

    public string? Himsnumber { get; set; }

    public int? RegionId { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public int? DefaultOwnerContactId { get; set; }

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

    public int? DefaultPmcontactId { get; set; }

    public bool? NoDefaultPm { get; set; }

    public string? PmcontactName { get; set; }

    public string? PmcompanyName { get; set; }

    public string? Pmaddress { get; set; }

    public string? Pmemail { get; set; }

    public string? Pmphone { get; set; }

    public string? PmhouseNum { get; set; }

    public string? PmhouseFracNum { get; set; }

    public string? Pmstreet { get; set; }

    public string? Pmunit { get; set; }

    public string? Pmcity { get; set; }

    public string? Pmstate { get; set; }

    public string? Pmzip { get; set; }

    public bool? IsCoveredProperty { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }

    public string? ProjectName { get; set; }

    public string? Typeofproject { get; set; }

    public string? HousingRegistryStatus { get; set; }

    public string PropertyCestype { get; set; } = null!;

    public string? PropertyAddress { get; set; }

    public string? AchpSiteZip { get; set; }

    public string? Neighborhood { get; set; }

    public int? NeighborhoodId { get; set; }

    public string? Apn { get; set; }

    public int? TotalProjectSiteMobilityUnit { get; set; }

    public int? TotalProjectSiteSensoryUnit { get; set; }

    public int TotalProjectSiteBothMobilityHvunit { get; set; }

    public int? TotalProjectSiteAccessibleUnit { get; set; }

    public string HasUnitData { get; set; } = null!;

    public int MobilityUnitCnt { get; set; }

    public int SensoryUnitCnt { get; set; }

    public int MobilitywHvunitCnt { get; set; }

    public int AdaptableUnitCnt { get; set; }

    public int EnhancedSensoryUnitCnt { get; set; }

    public int? AccessibleUnitCnt { get; set; }

    public string LowestAmi { get; set; } = null!;

    public int _0bedroom { get; set; }

    public int _1bedroom { get; set; }

    public int _2bedroom { get; set; }

    public int _3bedroom { get; set; }

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

    public string? CwlopenPriorRegistryDate { get; set; }

    public bool? IsCwlopenPriorRegistry { get; set; }
}
