using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutReviewReportSubItem
{
    public int LutReviewReportSubItemId { get; set; }

    public int LutReviewReportItemId { get; set; }

    public string SubItem { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsObselete { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<AssnSrreviewReportItemStatus> AssnSrreviewReportItemStatuses { get; set; } = new List<AssnSrreviewReportItemStatus>();

    public virtual LutReviewReportItem LutReviewReportItem { get; set; } = null!;
}
