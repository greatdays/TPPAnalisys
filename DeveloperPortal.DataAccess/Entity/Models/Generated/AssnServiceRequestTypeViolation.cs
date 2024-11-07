using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnServiceRequestTypeViolation
{
    public int LutServiceRequestTypeID { get; set; }

    public int LutViolationCategoryID { get; set; }

    public int LutViolationID { get; set; }

    public virtual LutServiceRequestType LutServiceRequestType { get; set; } = null!;

    public virtual LutViolation LutViolation { get; set; } = null!;

    public virtual LutViolationCategory LutViolationCategory { get; set; } = null!;
}
