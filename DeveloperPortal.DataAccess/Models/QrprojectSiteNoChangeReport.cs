using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrprojectSiteNoChangeReport
{
    public int QrprojectSiteNoChangeReportId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int ProjectSiteNoChangeReportId { get; set; }

    public bool? IsNoChangeInUs { get; set; }

    public bool? IsNoChangeInUuv { get; set; }

    public bool IsNoChangeInAutwl { get; set; }

    public bool IsNoChangeInAuwl { get; set; }

    public bool IsNoChangeInGl { get; set; }

    public bool IsNoChangeInRa { get; set; }

    public bool IsNoChangeInEc { get; set; }

    public bool IsNoChangeInOs { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSiteNoChangeReport ProjectSiteNoChangeReport { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
