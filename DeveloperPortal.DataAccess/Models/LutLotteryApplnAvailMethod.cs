using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutLotteryApplnAvailMethod
{
    public int LutLotteryApplnAvailMethodId { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmplotteryApplnAvailMethod> AssnPmplotteryApplnAvailMethods { get; set; } = new List<AssnPmplotteryApplnAvailMethod>();
}
