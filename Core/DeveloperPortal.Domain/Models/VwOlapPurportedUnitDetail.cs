using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapPurportedUnitDetail
{
    public int ProjectSiteId { get; set; }

    public int Projectid { get; set; }

    public int UnitPropSnapShotId { get; set; }

    public int UnitId { get; set; }

    public string? UnitNum { get; set; }

    public string? TotalBedroom { get; set; }

    public string? TotalBathroom { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public string? UnitType { get; set; }

    public string? Ami { get; set; }

    public string? OtherRentalSubsidy { get; set; }

    public bool? IsCes { get; set; }

    public int? IsAddendumSigned { get; set; }

    public bool? IsAccessible { get; set; }

    public int? MinOccupancy { get; set; }

    public int? MaxOccupancy { get; set; }

    public decimal? MinRent { get; set; }

    public decimal? MaxRent { get; set; }

    public decimal? MinDeposit { get; set; }

    public decimal? MaxDeposit { get; set; }

    public decimal? CreditScreeningFee { get; set; }

    public double? SquareFeet { get; set; }

    public string? Name { get; set; }

    public string? UnitAddress { get; set; }

    public string? ProjectName { get; set; }

    public string? Status { get; set; }

    public string? UnitAccessibiltyType { get; set; }

    public string? OccupancyRestrictions { get; set; }

    public int? IsPublicTransit { get; set; }

    public string? UnitFeature { get; set; }

    public string? UnitFeatureArea { get; set; }
}
