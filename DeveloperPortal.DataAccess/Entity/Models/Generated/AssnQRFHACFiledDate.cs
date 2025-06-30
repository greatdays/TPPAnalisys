using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnQrfhacfiledDate
{
    public int AssnQrfhacfiledDateId { get; set; }

    public int QrfairHousingId { get; set; }

    public int LutFhacfiledSourceId { get; set; }

    public DateOnly FhacfiledDate { get; set; }

    public virtual LutFhacfiledSource LutFhacfiledSource { get; set; } = null!;

    public virtual QrfairHousing QrfairHousing { get; set; } = null!;
}
