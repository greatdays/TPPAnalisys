using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPLotteryApplnAvailMethodSnap
{
    public int AssnPMPLotteryApplnAvailMethodSnapID { get; set; }

    public int? PMPSnapID { get; set; }

    public int? LutLotteryApplnAvailMethodID { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutLotteryApplnAvailMethod? LutLotteryApplnAvailMethod { get; set; }

    public virtual PMPSnap? PMPSnap { get; set; }
}
