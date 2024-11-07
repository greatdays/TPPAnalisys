using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnHRMApplicationPropQuestion
{
    public int AssnHRMApplicationPropQuestion1 { get; set; }

    public int HRMApplicationId { get; set; }

    public int LutProjectSiteQuestionId { get; set; }

    public string? Answer { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowID { get; set; }

    public virtual HRMApplication HRMApplication { get; set; } = null!;

    public virtual LutProjectSiteQuestion LutProjectSiteQuestion { get; set; } = null!;
}
