using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class NeighborhoodCouncil
{
    public int? ID { get; set; }

    public string LayerInfo { get; set; } = null!;

    public string? NeighborhoodCouncilName { get; set; }

    public string? EmpowerlaUrl { get; set; }

    public string? FolderPath { get; set; }

    public string? GeometryType { get; set; }

    public string? coordinates { get; set; }

    public string? WKT { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public string? Source { get; set; }

    public bool? IsObsoleted { get; set; }
}
