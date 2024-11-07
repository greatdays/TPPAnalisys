using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteNoChangeReport
{
    public int ProjectSiteNoChangeReportID { get; set; }

    public int ProjSitePropSnapShotID { get; set; }

    public bool? IsNoChangeInUS { get; set; }

    public bool? IsNoChangeInUUV { get; set; }

    public bool IsNoChangeInAUTWL { get; set; }

    public bool IsNoChangeInAUWL { get; set; }

    public bool IsNoChangeInGL { get; set; }

    public bool IsNoChangeInRA { get; set; }

    public bool IsNoChangeInEC { get; set; }

    public bool IsNoChangeInOS { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QRProjectSiteNoChangeReport> QRProjectSiteNoChangeReports { get; set; } = new List<QRProjectSiteNoChangeReport>();
}
