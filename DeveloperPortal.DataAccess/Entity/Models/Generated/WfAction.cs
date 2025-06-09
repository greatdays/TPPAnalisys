using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WfAction
{
    public int Id { get; set; }

    public int DefinitionId { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? Description { get; set; }

    public int? SourceStateId { get; set; }

    public int? DestinationStateId { get; set; }

    public int? ActionViewId { get; set; }

    public bool IsVisible { get; set; }

    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public int? CaseConditionId { get; set; }

    public string? CaseConditionParam { get; set; }

    public bool? IsBulk { get; set; }

    public virtual WfActionView? ActionView { get; set; }

    public virtual ICollection<AssnActionSchemaTemplate> AssnActionSchemaTemplates { get; set; } = new List<AssnActionSchemaTemplate>();

    public virtual WfCaseCondition? CaseCondition { get; set; }

    public virtual WfDefinition Definition { get; set; } = null!;

    public virtual WfState? DestinationState { get; set; }

    public virtual ICollection<LutImportantDate> LutImportantDates { get; set; } = new List<LutImportantDate>();

    public virtual WfState? SourceState { get; set; }

    public virtual ICollection<WfState> WfStates { get; set; } = new List<WfState>();

    public virtual ICollection<RoleMaster> Roles { get; set; } = new List<RoleMaster>();

    public virtual ICollection<RoleMaster> RolesNavigation { get; set; } = new List<RoleMaster>();
}
