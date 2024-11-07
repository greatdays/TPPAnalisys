using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class HRMApplicationAdditionalQuestion
{
    public int HRMApplicationAddQuestionId { get; set; }

    public int? HRMApplicationId { get; set; }

    public int? ProjectSiteSnapId { get; set; }

    public string? Question { get; set; }

    public string? QueAnswer { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual HRMApplication? HRMApplication { get; set; }

    public virtual ProjectSiteSnap? ProjectSiteSnap { get; set; }
}
