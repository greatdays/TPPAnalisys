using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnFhacfiledDate
{
    public int AssnFhacfiledDateId { get; set; }

    public int FairHousingId { get; set; }

    public int LutFhacfiledSourceId { get; set; }

    public DateTime FhacfiledDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual FairHousing FairHousing { get; set; } = null!;

    public virtual LutFhacfiledSource LutFhacfiledSource { get; set; } = null!;
}
