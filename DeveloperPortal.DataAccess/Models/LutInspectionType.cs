using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Look up table for Inspection Type.
/// </summary>
public partial class LutInspectionType
{
    public int LutInspectionTypeId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolete { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual ICollection<InspectionScheduled> InspectionScheduleds { get; set; } = new List<InspectionScheduled>();

    public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
}
