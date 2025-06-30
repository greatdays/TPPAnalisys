using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AkasiteAddressSnap
{
    public int AkasiteAddressSnapId { get; set; }

    public int ProjectSiteSnapId { get; set; }

    public int? RefSiteAddressId { get; set; }

    public int? SiteAddressId { get; set; }

    public string? HouseNum { get; set; }

    public string? HouseFracNum { get; set; }

    public string? PreDirCd { get; set; }

    public string? StreetName { get; set; }

    public string? StreetTypeCd { get; set; }

    public string? Apn { get; set; }

    public string? PostDirCd { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? ZipSuffix { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? FullAddress { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ProjectSiteSnap ProjectSiteSnap { get; set; } = null!;
}
