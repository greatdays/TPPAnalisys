using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutNeighborhood
{
    public int NeighborhoodId { get; set; }

    public string Type { get; set; } = null!;

    public int? RegionNumber { get; set; }

    public string? Location { get; set; }

    public int? ParentNeighborhoodId { get; set; }

    public string? GeoJsonGeometryType { get; set; }

    public string? GeoJsonCoordinates { get; set; }

    public string? Wkt { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid? RowId { get; set; }
}
