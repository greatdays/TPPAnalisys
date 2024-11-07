using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LACountyServicePlanningArea
{
    public int LACountyServicePlanningAreaID { get; set; }

    public int SPA { get; set; }

    public string SPAName { get; set; } = null!;

    public string SPAFullName { get; set; } = null!;

    public string? Year { get; set; }

    public string ServiceArea { get; set; } = null!;

    public string? GeoJsonGeometryType { get; set; }

    public string? GeoJsonCoordinates { get; set; }

    public string? WKT { get; set; }

    public string? Attribute { get; set; }

    public bool IsObsoleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
