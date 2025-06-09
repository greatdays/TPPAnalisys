using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_State
{
    public WF_State()
    {
        this.WF_Action = new HashSet<WF_Action>();
        this.WF_Action1 = new HashSet<WF_Action>();
    }

    public int Id { get; set; }

    public int DefinitionID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public int DueDays { get; set; }

    public bool IsTask { get; set; }

    public bool IsAuto { get; set; }

    public int? AutoNextActionID { get; set; }

    public int? AutoDefaultStatusDays { get; set; }

    public virtual WF_Action? WF_Action2 { get; set; }

    public virtual WfDefinition WF_Definition { get; set; } = null!;

    public virtual ICollection<WF_Action> WF_Action { get; set; } = new List<WF_Action>();

    public virtual ICollection<WF_Action> WF_Action1 { get; set; } = new List<WF_Action>();
}
