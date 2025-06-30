using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQrrentalSubsidy
{
    public int AssnQrrentalSubsidyId { get; set; }

    public int QroccupancyUnitId { get; set; }

    public int LutRentalSubsidyId { get; set; }

    public virtual LutRentalSubsidy LutRentalSubsidy { get; set; } = null!;

    public virtual QroccupancyUnit QroccupancyUnit { get; set; } = null!;
}
