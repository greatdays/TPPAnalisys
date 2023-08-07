using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class SpgridViewDisplayConfig
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
    /// This field is used for how many records you want to display on report.
    /// </summary>
    public int NoOfRecords { get; set; }

    /// <summary>
    /// This field is used to store set SPView accrodian setting is expand or collapse.
    /// </summary>
    public bool? IsCollapsed { get; set; }

    public bool? IsPaging { get; set; }

    public bool? IsSearch { get; set; }

    public string? HelpText { get; set; }

    public bool? IsFilter { get; set; }

    public string? FilterJson { get; set; }

    public bool? IsAda { get; set; }

    public string? Adajson { get; set; }

    public int? LutRenderTypeId { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual LutRenderType? LutRenderType { get; set; }

    public virtual SpviewSpconfig Spconfig { get; set; } = null!;

    public virtual ICollection<SpgridViewColumnConfig> SpgridViewColumnConfigs { get; set; } = new List<SpgridViewColumnConfig>();
}
