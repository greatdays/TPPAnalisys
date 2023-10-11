using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnHrmapplicationPropQuestion
{
    public int AssnHrmapplicationPropQuestion1 { get; set; }

    public int HrmapplicationId { get; set; }

    public int LutProjectSiteQuestionId { get; set; }

    public string? Answer { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public virtual Hrmapplication Hrmapplication { get; set; } = null!;

    public virtual LutProjectSiteQuestion LutProjectSiteQuestion { get; set; } = null!;
}
