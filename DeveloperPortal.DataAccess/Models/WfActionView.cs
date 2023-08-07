using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WfActionView
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

    public virtual ICollection<WfActionViewPermission> WfActionViewPermissions { get; set; } = new List<WfActionViewPermission>();

    public virtual ICollection<WfAction> WfActions { get; set; } = new List<WfAction>();
}
