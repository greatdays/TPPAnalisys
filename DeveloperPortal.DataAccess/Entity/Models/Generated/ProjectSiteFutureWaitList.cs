using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ProjectSiteFutureWaitList
{
    public int ProjectSiteFutureWaitListID { get; set; }

    public int ProjSitePropSnapShotID { get; set; }

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

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ICollection<QRProjectSiteFutureWaitList> QRProjectSiteFutureWaitLists { get; set; } = new List<QRProjectSiteFutureWaitList>();
}
