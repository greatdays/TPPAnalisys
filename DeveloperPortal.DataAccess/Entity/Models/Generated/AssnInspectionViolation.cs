using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnInspectionViolation
{
    public int InspectionId { get; set; }

    public int ViolationId { get; set; }

    public string? Operation { get; set; }

    public virtual Inspection Inspection { get; set; } = null!;

    public virtual Violation Violation { get; set; } = null!;
}
