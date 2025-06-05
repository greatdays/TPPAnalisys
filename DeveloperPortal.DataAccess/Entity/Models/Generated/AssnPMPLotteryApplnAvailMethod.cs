using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPmplotteryApplnAvailMethod
{
    public int AssnPmplotteryApplnAvailMethodId { get; set; }

    public int? Pmpid { get; set; }

    public int? LutLotteryApplnAvailMethodId { get; set; }

    public string? SpecialNote { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutLotteryApplnAvailMethod? LutLotteryApplnAvailMethod { get; set; }

    public virtual Pmp? Pmp { get; set; }
}
