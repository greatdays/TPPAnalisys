using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutReviewReportItem
{
    public int LutReviewReportItemId { get; set; }

    public string Item { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<AssnSrreviewReportItemStatus> AssnSrreviewReportItemStatuses { get; set; } = new List<AssnSrreviewReportItemStatus>();

    public virtual ICollection<LutPolicyReviewReportLanguage> LutPolicyReviewReportLanguages { get; set; } = new List<LutPolicyReviewReportLanguage>();

    public virtual ICollection<LutReviewReportSubItem> LutReviewReportSubItems { get; set; } = new List<LutReviewReportSubItem>();

    public virtual ICollection<ReviewReportItem> ReviewReportItems { get; set; } = new List<ReviewReportItem>();
}
