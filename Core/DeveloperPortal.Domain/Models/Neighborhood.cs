using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Neighborhood
{
    /// <summary>
    /// Primary Key Identity column for the Neighborhood table
    /// </summary>
    public int NeighborhoodId { get; set; }

    /// <summary>
    /// N = Neighborhood, R = Region
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// 1 Sorting sequence for Region
    /// </summary>
    public int? NeighborhoodNumber { get; set; }

    /// <summary>
    /// Name of Neighborhood or Region
    /// </summary>
    public string NeighborhoodName { get; set; } = null!;

    /// <summary>
    /// Neighborhood belongs to which region
    /// </summary>
    public int? ParentNeighborhoodId { get; set; }

    /// <summary>
    /// Geographic Json type
    /// </summary>
    public string? GeoJsonGeometryType { get; set; }

    /// <summary>
    /// Geographic Json cooridantes
    /// </summary>
    public string? GeoJsonCoordinates { get; set; }

    /// <summary>
    /// Well know text for the geometry
    /// </summary>
    public string? Wkt { get; set; }

    /// <summary>
    /// Created by date
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Created by Who
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Last Modifed date
    /// </summary>
    public DateTime ModifiedOn { get; set; }

    /// <summary>
    /// Last modified by
    /// </summary>
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Unique ID in System
    /// </summary>
    public Guid RowId { get; set; }

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
