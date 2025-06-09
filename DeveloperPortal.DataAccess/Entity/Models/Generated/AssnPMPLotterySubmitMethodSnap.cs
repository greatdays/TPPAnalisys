using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmplotterySubmitMethodSnap
{
    public int AssnPmplotterySubmitMethodSnapId { get; set; }

    public int? PmpsnapId { get; set; }

    public int? LutLotterySubmitMethodId { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual LutLotterySubmitMethod? LutLotterySubmitMethod { get; set; }

    public virtual Pmpsnap? Pmpsnap { get; set; }
}
