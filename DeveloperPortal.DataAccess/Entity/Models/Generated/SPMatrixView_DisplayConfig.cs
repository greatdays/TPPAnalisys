using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SPMatrixView_DisplayConfig
{
    /// <summary>
    /// DisplayConfigID is identity column.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to SPView_SPConfiguration
    /// </summary>
    public int SPConfigId { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// This field is used to store stored procedure paramater name and parameter value. 
    /// </summary>
    public string ParamNamenValue { get; set; } = null!;

    /// <summary>
    /// This field is used to store x coordinates column name of matrix report.
    /// </summary>
    public string RowField { get; set; } = null!;

    /// <summary>
    /// This field is used to store y coordinates column name of matrix report.
    /// </summary>
    public string ColumnField { get; set; } = null!;

    /// <summary>
    /// This field stores data column whose count will be displayed in matrix.
    /// </summary>
    public string? DataField { get; set; }

    /// <summary>
    /// This field is used to store how many records you want to display on report.
    /// </summary>
    public int? NoOfRecords { get; set; }

    /// <summary>
    /// This field is used to store set SPView accrodian setting is expand or collapse.
    /// </summary>
    public bool? IsCollapsed { get; set; }

    public bool? IsDisplayColumnTotal { get; set; }

    public bool? IsDisplayRowTotal { get; set; }

    public string? HelpText { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual SPView_SPConfig SPConfig { get; set; } = null!;
}
