using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQRFHACFiledDate
{
    public int AssnQRFHACFiledDateID { get; set; }

    public int QRFairHousingID { get; set; }

    public int LutFHACFiledSourceID { get; set; }

    public DateOnly FHACFiledDate { get; set; }

    public virtual LutFHACFiledSource LutFHACFiledSource { get; set; } = null!;

    public virtual QRFairHousing QRFairHousing { get; set; } = null!;
}
