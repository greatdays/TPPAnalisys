using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutPolicyReviewReportLanguage
{
    public int LutReviewReportLanguageID { get; set; }

    public int ReviewReportItemID { get; set; }

    public string? TemplateIdentifier { get; set; }

    public string ReportLanguage { get; set; } = null!;

    public string ProjectType { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutReviewReportItem ReviewReportItem { get; set; } = null!;
}
