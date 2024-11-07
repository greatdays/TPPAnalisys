using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwCaseLog
{
    public int CaseLogID { get; set; }

    public int CaseID { get; set; }

    public string ActionName { get; set; } = null!;

    public string? FromState { get; set; }

    public string ToState { get; set; } = null!;

    public string? LastAssigneeID { get; set; }

    public string? NewAssigneeID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? CreatedUserName { get; set; }

    public DateTime CreatedOn { get; set; }
}
