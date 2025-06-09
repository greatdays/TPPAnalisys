using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Tcaselog
{
    public int CaseLogId { get; set; }

    public int CaseId { get; set; }

    public string Action { get; set; } = null!;

    public string? FromState { get; set; }

    public string ToState { get; set; } = null!;

    public string? LastAssigneeId { get; set; }

    public string? NewAssigneeId { get; set; }

    public string? LastAssigneeName { get; set; }

    public string? NewAssigneeName { get; set; }

    public string? CaseComment { get; set; }

    public string? WorkLog { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
