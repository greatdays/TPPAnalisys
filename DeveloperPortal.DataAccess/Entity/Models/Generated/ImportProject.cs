using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ImportProject
{
    public int Id { get; set; }

    public string GroupImport { get; set; } = null!;

    public int GroupImportStatus { get; set; }

    public string Prefix { get; set; } = null!;

    public bool? IsCovered { get; set; }

    public bool? IsAccessible { get; set; }

    public bool? IsAffordable { get; set; }

    public bool? IsAccessibleAffordable { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyName { get; set; }

    public int? SiteNum { get; set; }

    public string? LutProjSourceCd { get; set; }

    public int LutProjectFundId { get; set; }

    public int LutTypeofProjectId { get; set; }

    public string? FileGroup { get; set; }

    public string? FileNumber { get; set; }

    public string? Source { get; set; }

    public int? SourceRefId { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public int? SiteAddressId { get; set; }

    public string? PrimaryApn { get; set; }

    public string? SiteAddress { get; set; }

    public string? Himsnumber { get; set; }

    public int? HimsprojUniqueId { get; set; }

    public string? CouncilDistrict { get; set; }

    public int? RegionId { get; set; }

    public int? NeighborhoodId { get; set; }

    public int? TotalSiteUnit { get; set; }

    public int? MobilityUnit { get; set; }

    public int? SensoryUnit { get; set; }

    public decimal? MobilityRatio { get; set; }

    public decimal? Hvratio { get; set; }

    public string? Cestype { get; set; }

    public int? LutProjectSiteStatusId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ImportLog { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public int? ZipCode { get; set; }

    public bool? HasExistingProject { get; set; }

    public string? SettlementAddress { get; set; }

    public short? SettlementMobilityUnit { get; set; }

    public short? SettlementSensoryUnit { get; set; }

    public short? SettlementTotalAccessibleUnit { get; set; }

    public short? SettlementTotalUnit { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? YearStart { get; set; }

    public string? YearEnd { get; set; }

    public string? Neighborhood { get; set; }

    public string? Region { get; set; }
}
