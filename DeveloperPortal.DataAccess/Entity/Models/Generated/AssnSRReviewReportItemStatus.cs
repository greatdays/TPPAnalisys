using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnSrreviewReportItemStatus
{
    public int AssnServiceRequestReviewReportId { get; set; }

    public long ServiceRequestId { get; set; }

    public int LutReviewReportItemId { get; set; }

    public int LutReviewReportSubItemId { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual LutReviewReportItem LutReviewReportItem { get; set; } = null!;

    public virtual LutReviewReportSubItem LutReviewReportSubItem { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
