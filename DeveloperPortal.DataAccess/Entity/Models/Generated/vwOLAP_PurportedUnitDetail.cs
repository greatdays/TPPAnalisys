using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_PurportedUnitDetail
{
    public int ProjectSiteID { get; set; }

    public int projectid { get; set; }

    public int UnitPropSnapShotID { get; set; }

    public int UnitID { get; set; }

    public string? UnitNum { get; set; }

    public string? TotalBedroom { get; set; }

    public string? TotalBathroom { get; set; }

    public bool? IsOccupiedByDisabled { get; set; }

    public bool? IsOccupied { get; set; }

    public string? UnitType { get; set; }

    public string? AMI { get; set; }

    public string? OtherRentalSubsidy { get; set; }

    public bool? IsCES { get; set; }

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

    public string? PropertyName { get; set; }

    public string? Status { get; set; }

    public string? UnitAccessibiltyType { get; set; }

    public DateTime? Unit_Attribute_Date { get; set; }

    public string? OccupancyRestrictions { get; set; }

    public int? IsPublicTransit { get; set; }

    public string? UnitFeature { get; set; }

    public string? UnitFeatureArea { get; set; }

    public int isCertified { get; set; }

    public DateOnly? LeaseAddendumExecutedDate { get; set; }

    public string? currentTenant { get; set; }

    public bool? IsManagersUnit { get; set; }

    public string? FixedOrFloating { get; set; }

    public bool? IsLeaseAddendumExpirationDate { get; set; }

    public DateOnly? LeaseAddendumExpirationDate { get; set; }

    public string? PreviousTenantMoved { get; set; }

    public DateOnly? TenantMovedToAnotherUnitDate { get; set; }

    public string? TenantSelectedFrom { get; set; }

    public string? CountAs { get; set; }

    public string? NatureOfReasonableModification { get; set; }
}
