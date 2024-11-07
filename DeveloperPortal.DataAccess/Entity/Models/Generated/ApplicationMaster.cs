using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// This table holds information about various application that intends to use Common Controls.
/// </summary>
public partial class ApplicationMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? ApplicationGUID { get; set; }

    public virtual ICollection<AppConfig> AppConfigs { get; set; } = new List<AppConfig>();

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();

    public virtual ICollection<RoleMaster> RoleMasters { get; set; } = new List<RoleMaster>();

    public virtual ICollection<TabMaster> TabMasters { get; set; } = new List<TabMaster>();

    public virtual ICollection<WF_Definition> WF_Definitions { get; set; } = new List<WF_Definition>();

    public virtual ICollection<ApplicationMaster> Applications { get; set; } = new List<ApplicationMaster>();

    public virtual ICollection<CaseType> CaseTypes { get; set; } = new List<CaseType>();

    public virtual ICollection<ApplicationMaster> ModuleApplicatinos { get; set; } = new List<ApplicationMaster>();
}
