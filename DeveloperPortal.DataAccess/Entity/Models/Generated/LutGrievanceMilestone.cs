using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGrievanceMilestone
{
    public int LutGrievanceMilestonesID { get; set; }

    public string MilestoneName { get; set; } = null!;

    public int? ViewOrder { get; set; }

    public bool IsMultiple { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<AssnGrievanceMilestonesDate> AssnGrievanceMilestonesDates { get; set; } = new List<AssnGrievanceMilestonesDate>();
}
