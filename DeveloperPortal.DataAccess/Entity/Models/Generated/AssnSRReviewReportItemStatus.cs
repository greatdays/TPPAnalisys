using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnSRReviewReportItemStatus
{
    public int AssnServiceRequestReviewReportID { get; set; }

    public long ServiceRequestID { get; set; }

    public int LutReviewReportItemID { get; set; }

    public int LutReviewReportSubItemID { get; set; }

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
