using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmplotteryApplnAvailMethodSnap
{
    public int AssnPmplotteryApplnAvailMethodSnapId { get; set; }

    public int? PmpsnapId { get; set; }

    public int? LutLotteryApplnAvailMethodId { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutLotteryApplnAvailMethod? LutLotteryApplnAvailMethod { get; set; }

    public virtual Pmpsnap? Pmpsnap { get; set; }
}
