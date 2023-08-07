using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class HrmapplicationAdditionalQuestion
{
    public int HrmapplicationAddQuestionId { get; set; }

    public int? HrmapplicationId { get; set; }

    public int? ProjectSiteSnapId { get; set; }

    public string? Question { get; set; }

    public string? QueAnswer { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Hrmapplication? Hrmapplication { get; set; }

    public virtual ProjectSiteSnap? ProjectSiteSnap { get; set; }
}
