using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WfState
{
    public int Id { get; set; }

    public int DefinitionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public int DueDays { get; set; }

    public bool IsTask { get; set; }

    public bool IsAuto { get; set; }

    public int? AutoNextActionId { get; set; }

    public int? AutoDefaultStatusDays { get; set; }

    public virtual WfAction? AutoNextAction { get; set; }

    public virtual WfDefinition Definition { get; set; } = null!;

    public virtual ICollection<WfAction> WfActionDestinationStates { get; set; } = new List<WfAction>();

    public virtual ICollection<WfAction> WfActionSourceStates { get; set; } = new List<WfAction>();
}
