using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class NeighborhoodCouncil
{
    public int? Id { get; set; }

    public string LayerInfo { get; set; } = null!;

    public string? NeighborhoodCouncilName { get; set; }

    public string? EmpowerlaUrl { get; set; }

    public string? FolderPath { get; set; }

    public string? GeometryType { get; set; }

    public string? Coordinates { get; set; }

    public string? Wkt { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Source { get; set; }

    public bool? IsObsoleted { get; set; }
}
