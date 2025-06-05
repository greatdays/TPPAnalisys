using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SpdetailViewDisplayConfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to SPView_SPConfiguration
    /// </summary>
    public int SpconfigId { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// This field is used to store stored procedure paramater name and parameter value. 
    /// </summary>
    public string ParamNamenValue { get; set; } = null!;

    /// <summary>
    /// This field is used to store how many columns display on SPView section.
    /// </summary>
    public int NoOfViewColumns { get; set; }

    /// <summary>
    /// This field is used to store set SPView accrodian setting is expand or collapse.
    /// </summary>
    public bool? IsCollapsed { get; set; }

    public string? HelpText { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual SpviewSpconfig Spconfig { get; set; } = null!;

    public virtual ICollection<SpdetailViewColumnConfig> SpdetailViewColumnConfigs { get; set; } = new List<SpdetailViewColumnConfig>();
}
