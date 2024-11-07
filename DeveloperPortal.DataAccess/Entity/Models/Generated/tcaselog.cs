using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class tcaselog
{
    public int CaseLogID { get; set; }

    public int CaseID { get; set; }

    public string Action { get; set; } = null!;

    public string? FromState { get; set; }

    public string ToState { get; set; } = null!;

    public string? LastAssigneeID { get; set; }

    public string? NewAssigneeID { get; set; }

    public string? LastAssigneeName { get; set; }

    public string? NewAssigneeName { get; set; }

    public string? CaseComment { get; set; }

    public string? WorkLog { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
