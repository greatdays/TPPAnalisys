using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPMPLotteryApplnAvailMethod
{
    public int AssnPMPLotteryApplnAvailMethodID { get; set; }

    public int? PMPID { get; set; }

    public int? LutLotteryApplnAvailMethodID { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutLotteryApplnAvailMethod? LutLotteryApplnAvailMethod { get; set; }

    public virtual PMP? PMP { get; set; }
}
