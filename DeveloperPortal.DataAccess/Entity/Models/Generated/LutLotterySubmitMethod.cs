using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLotterySubmitMethod
{
    public int LutLotterySubmitMethodID { get; set; }

    public string Name { get; set; } = null!;

    public bool? SpecialNoteRequired { get; set; }

    public bool? IsObsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPMPLotterySubmitMethodSnap> AssnPMPLotterySubmitMethodSnaps { get; set; } = new List<AssnPMPLotterySubmitMethodSnap>();

    public virtual ICollection<AssnPMPLotterySubmitMethod> AssnPMPLotterySubmitMethods { get; set; } = new List<AssnPMPLotterySubmitMethod>();
}
