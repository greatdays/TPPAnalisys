using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAAHRPropertiesToGetLADBSPermit
{
    public string? PropertyName { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? ZipSuffix { get; set; }

    public string? PrimaryAPN { get; set; }

    public string? PIN { get; set; }

    public int SourceID { get; set; }

    public string? SourceReferenceNumber { get; set; }

    public string SourceType { get; set; } = null!;

    public string? ProjectCategory { get; set; }

    public int? ProjectCategoryid { get; set; }

    public int? ProjectStatusCd { get; set; }

    public string? HIMSNumber { get; set; }

    public DateTime CreatedOn { get; set; }
}
