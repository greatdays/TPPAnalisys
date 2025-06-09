using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnLocationCategoryLocation
{
    public int LutLocationCategoryId { get; set; }

    public int LutViolationLocationId { get; set; }

    public virtual LutLocationCategory LutLocationCategory { get; set; } = null!;

    public virtual LutViolationLocation LutViolationLocation { get; set; } = null!;
}
