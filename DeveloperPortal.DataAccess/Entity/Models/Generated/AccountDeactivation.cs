using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AccountDeactivation
{
    public int AccountDeactivationId { get; set; }

    public string? Idmusename { get; set; }

    public int? ContactIdentifierId { get; set; }

    public DateTime? DateRequestedForDeactive { get; set; }

    public string? ReasonForDeactive { get; set; }

    public bool? IsRequestedReactivate { get; set; }

    public string? ReasonForReactivate { get; set; }

    public DateTime? DateRequestedForReactivate { get; set; }

    public string? ActionTaken { get; set; }

    public bool? IsAccountDeactivated { get; set; }

    public string? DateStaffTookAction { get; set; }

    public string? ActionTakenByStaff { get; set; }

    public bool? IsRequestInProcess { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
