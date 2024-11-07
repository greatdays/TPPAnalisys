using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_State
{
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

    public virtual WF_Action? AutoNextAction { get; set; }

    public virtual WF_Definition Definition { get; set; } = null!;

    public virtual ICollection<WF_Action> WF_ActionDestinationStates { get; set; } = new List<WF_Action>();

    public virtual ICollection<WF_Action> WF_ActionSourceStates { get; set; } = new List<WF_Action>();
}
