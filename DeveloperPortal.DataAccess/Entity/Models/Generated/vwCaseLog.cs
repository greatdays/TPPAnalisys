using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwCaseLog
{
    public int CaseLogId { get; set; }

    public int CaseId { get; set; }

    public string ActionName { get; set; } = null!;

    public string? FromState { get; set; }

    public string ToState { get; set; } = null!;

    public string? LastAssigneeId { get; set; }

    public string? NewAssigneeId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? CreatedUserName { get; set; }

    public DateTime CreatedOn { get; set; }
}
