using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ReviewReportItem
{
    public int ReviewReportItemId { get; set; }

    public int ReviewReportDetailId { get; set; }

    public int LutReviewReportItemId { get; set; }

    public string? ReportLanguage { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public virtual LutReviewReportItem LutReviewReportItem { get; set; } = null!;

    public virtual ReviewReportDetail ReviewReportDetail { get; set; } = null!;
}
