using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class WfDefinition
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    public string? DiagramData { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ApplicationMaster? Application { get; set; }

    public virtual ICollection<CaseType> CaseTypes { get; set; } = new List<CaseType>();

    public virtual ICollection<WfAction> WfActions { get; set; } = new List<WfAction>();

    public virtual ICollection<WfState> WfStates { get; set; } = new List<WfState>();

    public virtual ICollection<WflogDisplayConfig> WflogDisplayConfigs { get; set; } = new List<WflogDisplayConfig>();

    public virtual ICollection<WfnavigationDisplayConfig> WfnavigationDisplayConfigs { get; set; } = new List<WfnavigationDisplayConfig>();
}
