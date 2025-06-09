using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteFutureWaitList
{
    public int ProjectSiteFutureWaitListId { get; set; }

    public int ProjSitePropSnapShotId { get; set; }

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

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QrprojectSiteFutureWaitList> QrprojectSiteFutureWaitLists { get; set; } = new List<QrprojectSiteFutureWaitList>();
}
