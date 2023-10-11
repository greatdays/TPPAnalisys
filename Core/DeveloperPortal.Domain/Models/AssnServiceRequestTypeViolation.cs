using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnServiceRequestTypeViolation
{
    public int LutServiceRequestTypeId { get; set; }

    public int LutViolationCategoryId { get; set; }

    public int LutViolationId { get; set; }

    public virtual LutServiceRequestType LutServiceRequestType { get; set; } = null!;

    public virtual LutViolation LutViolation { get; set; } = null!;

    public virtual LutViolationCategory LutViolationCategory { get; set; } = null!;
}
