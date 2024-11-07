using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ReviewReportItem
{
    public int ReviewReportItemID { get; set; }

    public int ReviewReportDetailID { get; set; }

    public int LutReviewReportItemID { get; set; }

    public string? ReportLanguage { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public virtual LutReviewReportItem LutReviewReportItem { get; set; } = null!;

    public virtual ReviewReportDetail ReviewReportDetail { get; set; } = null!;
}
