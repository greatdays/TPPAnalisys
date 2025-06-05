using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QrprojectSiteFutureWaitList
{
    public int QrprojectSiteFutureWaitListId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int ProjectSiteFutureWaitListId { get; set; }

    public bool? IsWaitListOpenInFuture { get; set; }

    public int? NoOfApplicantOnCuwl { get; set; }

    public int? NoOfApplicantOnCuwlseekAh { get; set; }

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
