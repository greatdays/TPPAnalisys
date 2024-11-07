using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_Action
{
    public int Id { get; set; }

    public int DefinitionID { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? Description { get; set; }

    public int? SourceStateID { get; set; }

    public int? DestinationStateID { get; set; }

    public int? ActionViewID { get; set; }

    public bool IsVisible { get; set; }

    public bool IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public int? CaseConditionID { get; set; }

    public string? CaseConditionParam { get; set; }

    public bool? IsBulk { get; set; }

    public virtual WF_ActionView? ActionView { get; set; }

    public virtual ICollection<AssnActionSchemaTemplate> AssnActionSchemaTemplates { get; set; } = new List<AssnActionSchemaTemplate>();

    public virtual WF_CaseCondition? CaseCondition { get; set; }

    public virtual WF_Definition Definition { get; set; } = null!;

    public virtual WF_State? DestinationState { get; set; }

    public virtual ICollection<LutImportantDate> LutImportantDates { get; set; } = new List<LutImportantDate>();

    public virtual WF_State? SourceState { get; set; }

    public virtual ICollection<WF_State> WF_States { get; set; } = new List<WF_State>();

    public virtual ICollection<RoleMaster> Roles { get; set; } = new List<RoleMaster>();

    public virtual ICollection<RoleMaster> RolesNavigation { get; set; } = new List<RoleMaster>();
}
