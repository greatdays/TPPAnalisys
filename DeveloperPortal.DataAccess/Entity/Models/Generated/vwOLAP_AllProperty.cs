using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_AllProperty
{
    public int? ProjectSiteSnapID { get; set; }

    public string? PropertyName { get; set; }

    public int ProjectID { get; set; }

    public string? ACHPFileNumberProject { get; set; }

    public int ProjectSiteID { get; set; }

    public int RefProjectSiteID { get; set; }

    public string? FileNumber { get; set; }

    public int? PropSnapshotID { get; set; }

    public int? SiteNum { get; set; }

    public string? HIMSNumber { get; set; }

    public int? RegionID { get; set; }

    public string? RegionName { get; set; }

    public string? CouncilDistrict { get; set; }

    public string? Source { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? HVRatio { get; set; }

    public string? NeighborhoodCouncil { get; set; }

    public bool? IsCoveredProperty { get; set; }

    public decimal? LAT { get; set; }

    public decimal? lon { get; set; }

    public string? ProjectName { get; set; }

    public string? typeofproject { get; set; }

    public string? HousingRegistryStatus { get; set; }

    public string PropertyCESType { get; set; } = null!;

    public string HousingProgram { get; set; } = null!;

    public string? HouseNum { get; set; }

    public string? PostDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? City { get; set; }

    public string? state { get; set; }

    public string? ZipCode { get; set; }

    public string? PropertyAddress { get; set; }

    public string? Neighborhood { get; set; }

    public int? NeighborhoodID { get; set; }

    public string? APN { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public DateTime? ConventionalWaitListOpenDate { get; set; }

    public DateTime? ConventionalWaitListCloseDate { get; set; }

    public DateTime? OpenForApplication { get; set; }

    public DateTime? OpenForMarketing { get; set; }

    public DateTime? DateSubsequentAUMarketing { get; set; }

    public string RentalInformation { get; set; } = null!;

    public string RentalPolicy { get; set; } = null!;

    public string SpecialNotes { get; set; } = null!;

    public string PropertyDescription { get; set; } = null!;

    public string PropertyWebsite { get; set; } = null!;

    public string RentalApplicationLink { get; set; } = null!;

    public bool? IsSharedLiving { get; set; }

    public bool? IsScreeningFee { get; set; }

    public decimal? ApplicationFee { get; set; }

    public decimal? ScreeningFee { get; set; }

    public bool? IsAdultFee { get; set; }

    public bool? IsCreditCheck { get; set; }

    public bool? IsCriminalCheck { get; set; }

    public string? ParkingType { get; set; }

    public decimal? ParkingFees { get; set; }

    public string AmmenitiesDescription { get; set; } = null!;

    public string FundSources { get; set; } = null!;

    public DateTime? LastPublishedDate { get; set; }

    public int TransitAccessible { get; set; }

    public string? DistanceToTransit { get; set; }

    public DateTime? DatePMPostedDataOnAHR { get; set; }

    public DateTime? DateLADBSInitialCertificateOccupancy { get; set; }

    public string PriorSurvey { get; set; } = null!;

    public string? TTYNumber { get; set; }

    public int? HIMSProjUniqueId { get; set; }

    public string? TypeOfConstruction { get; set; }

    public string? ListingStatus { get; set; }

    public string? SubmittedBy { get; set; }

    public string? ScatteredSites { get; set; }

    public string? NearByServices { get; set; }

    public string? DistanceToNearByServices { get; set; }

    public string? FeatureArea { get; set; }

    public string? Features { get; set; }

    public string? TransitWithinOneMile { get; set; }

    public string? OccupancyStatus { get; set; }

    public bool? IsSiteOccupiedPrior2015 { get; set; }

    public DateOnly? OccupancyNotificationDate { get; set; }

    public bool? IsSiteCurrentlyOccupied { get; set; }

    public DateOnly? ReportedFullOccupancyDate { get; set; }

    public DateOnly? OwnershipChangeDate { get; set; }

    public DateOnly? PolicyCertDueDate { get; set; }

    public string? ProjectSiteStatus { get; set; }

    public DateTime? projectSiteStatusChangeDate { get; set; }

    public string? PropertyFullAddress { get; set; }
}
