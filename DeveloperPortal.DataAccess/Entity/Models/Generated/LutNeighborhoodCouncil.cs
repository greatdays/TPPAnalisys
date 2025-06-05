using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutNeighborhoodCouncil
{
    public int? Id { get; set; }

    public string LayerYearDescription { get; set; } = null!;

    public string? NeighborhoodCouncil { get; set; }

    public string? NeighborhoodCouncilName { get; set; }

    public string? EmpowerlaUrl { get; set; }

    public string? FolderPath { get; set; }

    public string? GeometryType { get; set; }

    public string? Coordinates { get; set; }

    public string Wkt { get; set; } = null!;
}
