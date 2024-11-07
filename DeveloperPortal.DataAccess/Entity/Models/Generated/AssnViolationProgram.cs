using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnViolationProgram
{
    public int LutViolationID { get; set; }

    public Guid ApplicationGUID { get; set; }

    public virtual LutViolation LutViolation { get; set; } = null!;
}
