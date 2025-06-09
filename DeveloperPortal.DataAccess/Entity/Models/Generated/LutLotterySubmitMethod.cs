using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLotterySubmitMethod
{
    public int LutLotterySubmitMethodId { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmplotterySubmitMethodSnap> AssnPmplotterySubmitMethodSnaps { get; set; } = new List<AssnPmplotterySubmitMethodSnap>();

    public virtual ICollection<AssnPmplotterySubmitMethod> AssnPmplotterySubmitMethods { get; set; } = new List<AssnPmplotterySubmitMethod>();
}
