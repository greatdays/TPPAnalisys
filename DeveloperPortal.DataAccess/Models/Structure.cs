using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Structure
{
    public int StructureId { get; set; }

    public int? RefBuildingId { get; set; }

    public int Apnid { get; set; }

    public int? LutStructureTypeId { get; set; }

    public string? Description { get; set; }

    public DateTime? DateBuilt { get; set; }

    public DateTime? DateDemolished { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? SourceRefId { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public string? StructureNo { get; set; }

    public string? Label { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? TotalUnits { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? BuildingFileNumber { get; set; }

    public virtual Apn Apn { get; set; } = null!;

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual LutStructureType1? LutStructureType { get; set; }

    public virtual ICollection<PropSnapshot> PropSnapshots { get; set; } = new List<PropSnapshot>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<SiteAddress> SiteAddresses { get; set; } = new List<SiteAddress>();
}
