using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteNoChangeReport
{
    public int ProjectSiteNoChangeReportId { get; set; }

    public int ProjSitePropSnapShotId { get; set; }

    public bool? IsNoChangeInUs { get; set; }

    public bool? IsNoChangeInUuv { get; set; }

    public bool? IsNoChangeInAutwl { get; set; }

    public bool? IsNoChangeInAuwl { get; set; }

    public bool? IsNoChangeInGl { get; set; }

    public bool? IsNoChangeInRa { get; set; }

    public bool? IsNoChangeInEc { get; set; }

    public bool? IsNoChangeInOs { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QrprojectSiteNoChangeReport> QrprojectSiteNoChangeReports { get; set; } = new List<QrprojectSiteNoChangeReport>();
}
