using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnGrievanceMilestonesDate
{
    public int GrievanceID { get; set; }

    public int LutGrievanceMilestonesID { get; set; }

    public DateOnly MilestoneDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Grievance Grievance { get; set; } = null!;

    public virtual LutGrievanceMilestone LutGrievanceMilestones { get; set; } = null!;
}
