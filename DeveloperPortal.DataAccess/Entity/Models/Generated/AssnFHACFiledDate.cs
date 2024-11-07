using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnFHACFiledDate
{
    public int AssnFHACFiledDateID { get; set; }

    public int FairHousingID { get; set; }

    public int LutFHACFiledSourceID { get; set; }

    public DateOnly FHACFiledDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual FairHousing FairHousing { get; set; } = null!;

    public virtual LutFHACFiledSource LutFHACFiledSource { get; set; } = null!;
}
