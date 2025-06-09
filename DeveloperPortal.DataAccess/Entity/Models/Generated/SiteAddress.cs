using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SiteAddress
{
    public int SiteAddressId { get; set; }

    public int? RefSiteAddressId { get; set; }

    public string? Pin { get; set; }

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

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? FullAddress { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public bool? IsConfidentialAddr { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PmpprojectSiteSnap> PmpprojectSiteSnaps { get; set; } = new List<PmpprojectSiteSnap>();

    public virtual ICollection<PmpunitSnap> PmpunitSnaps { get; set; } = new List<PmpunitSnap>();

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<Apn> Apns { get; set; } = new List<Apn>();

    public virtual ICollection<Structure> Structures { get; set; } = new List<Structure>();
}
