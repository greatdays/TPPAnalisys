using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQRRentalSubsidy
{
    public int AssnQRRentalSubsidyID { get; set; }

    public int QROccupancyUnitID { get; set; }

    public int LutRentalSubsidyID { get; set; }

    public virtual LutRentalSubsidy LutRentalSubsidy { get; set; } = null!;

    public virtual QROccupancyUnit QROccupancyUnit { get; set; } = null!;
}
