using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LacountyServicePlanningArea
{
    public int LacountyServicePlanningAreaId { get; set; }

    public int Spa { get; set; }

    public string Spaname { get; set; } = null!;

    public string SpafullName { get; set; } = null!;

    public string? Year { get; set; }

    public string ServiceArea { get; set; } = null!;

    public string? GeoJsonGeometryType { get; set; }

    public string? GeoJsonCoordinates { get; set; }

    public string? Wkt { get; set; }

    public string? Attribute { get; set; }

    public bool IsObsoleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
