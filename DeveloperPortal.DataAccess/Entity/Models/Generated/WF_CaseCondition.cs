using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// This table holds condition based on assignee or creator of the case. 
/// e.g. 
/// Assignee/Craetor Only will ignore previlleage to Role category and only the assignee/creator will view the option.
/// </summary>
public partial class WF_CaseCondition
{
    public int Id { get; set; }

    public string Condition { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<WF_Action> WF_Actions { get; set; } = new List<WF_Action>();
}
