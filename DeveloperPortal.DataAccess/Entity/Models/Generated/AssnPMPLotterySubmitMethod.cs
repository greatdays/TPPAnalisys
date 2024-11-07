using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPLotterySubmitMethod
{
    public int AssnPMPLotterySubmitMethodID { get; set; }

    public int? PMPID { get; set; }

    public int? LutLotterySubmitMethodID { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutLotterySubmitMethod? LutLotterySubmitMethod { get; set; }

    public virtual PMP? PMP { get; set; }
}
