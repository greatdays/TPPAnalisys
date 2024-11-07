using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRProjectSiteFutureWaitList
{
    public int QRProjectSiteFutureWaitListID { get; set; }

    public int QuarterlyReportID { get; set; }

    public int ProjectSiteFutureWaitListID { get; set; }

    public bool? IsWaitListOpenInFuture { get; set; }

    public int? NoOfApplicantOnCUWL { get; set; }

    public int? NoOfApplicantOnCUWLSeekAH { get; set; }

    public bool? IsPlanToConductOutReach { get; set; }

    public DateTime? OutReachConductDate { get; set; }

    public string? PropertyStatus { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSiteFutureWaitList ProjectSiteFutureWaitList { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
