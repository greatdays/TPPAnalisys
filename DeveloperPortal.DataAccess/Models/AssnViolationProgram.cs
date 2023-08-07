using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnViolationProgram
{
    public int LutViolationId { get; set; }

    public Guid ApplicationGuid { get; set; }

    public virtual LutViolation LutViolation { get; set; } = null!;
}
