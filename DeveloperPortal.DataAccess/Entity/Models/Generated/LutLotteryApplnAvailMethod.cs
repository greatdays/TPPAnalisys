using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLotteryApplnAvailMethod
{
    public int LutLotteryApplnAvailMethodID { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPMPLotteryApplnAvailMethodSnap> AssnPMPLotteryApplnAvailMethodSnaps { get; set; } = new List<AssnPMPLotteryApplnAvailMethodSnap>();

    public virtual ICollection<AssnPMPLotteryApplnAvailMethod> AssnPMPLotteryApplnAvailMethods { get; set; } = new List<AssnPMPLotteryApplnAvailMethod>();
}
