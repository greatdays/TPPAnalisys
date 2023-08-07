using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ProjectSiteSnapLog
{
    public int ProjectSiteSnapLogId { get; set; }

    public int? ProjectSiteSnapId { get; set; }

    public string? Attributes { get; set; }

    public DateTime? WaitListCloseDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ActionPeformed { get; set; }

    public DateTime? LogCreatedOn { get; set; }

    public string? CloseDateReasonByOpm { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }
}
