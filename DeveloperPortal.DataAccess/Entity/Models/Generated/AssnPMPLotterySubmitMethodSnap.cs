using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPLotterySubmitMethodSnap
{
    public int AssnPMPLotterySubmitMethodSnapID { get; set; }

    public int? PMPSnapID { get; set; }

    public int? LutLotterySubmitMethodID { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutLotterySubmitMethod? LutLotterySubmitMethod { get; set; }

    public virtual PMPSnap? PMPSnap { get; set; }
}
