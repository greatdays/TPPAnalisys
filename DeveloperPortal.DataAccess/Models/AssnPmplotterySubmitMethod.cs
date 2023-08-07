using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnPmplotterySubmitMethod
{
    public int AssnPmplotterySubmitMethodId { get; set; }

    public int? Pmpid { get; set; }

    public int? LutLotterySubmitMethodId { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutLotterySubmitMethod? LutLotterySubmitMethod { get; set; }

    public virtual Pmp? Pmp { get; set; }
}
