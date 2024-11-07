using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_ActionView
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Area { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public string? Parameters { get; set; }

    public bool? IsWindow { get; set; }

    public bool? IsCustom { get; set; }

    public int? FormId { get; set; }

    public virtual ICollection<WF_ActionViewPermission> WF_ActionViewPermissions { get; set; } = new List<WF_ActionViewPermission>();

    public virtual ICollection<WF_Action> WF_Actions { get; set; } = new List<WF_Action>();
}
