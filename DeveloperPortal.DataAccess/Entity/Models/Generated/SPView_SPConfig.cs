using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SPView_SPConfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to SPView_DBConfiguration table
    /// </summary>
    public int DBConfigId { get; set; }

    /// <summary>
    /// This field is used to store stored procedure name which is exists on selected database server.
    /// </summary>
    public string SPName { get; set; } = null!;

    public virtual SPView_DBConfig DBConfig { get; set; } = null!;

    public virtual ICollection<SPDetailView_ColumnConfig> SPDetailView_ColumnConfigs { get; set; } = new List<SPDetailView_ColumnConfig>();

    public virtual ICollection<SPDetailView_DisplayConfig> SPDetailView_DisplayConfigs { get; set; } = new List<SPDetailView_DisplayConfig>();

    public virtual ICollection<SPGridView_ColumnConfig> SPGridView_ColumnConfigs { get; set; } = new List<SPGridView_ColumnConfig>();

    public virtual ICollection<SPGridView_DisplayConfig> SPGridView_DisplayConfigs { get; set; } = new List<SPGridView_DisplayConfig>();

    public virtual ICollection<SPGroupView_ColumnConfig> SPGroupView_ColumnConfigs { get; set; } = new List<SPGroupView_ColumnConfig>();

    public virtual ICollection<SPGroupView_DisplayConfig> SPGroupView_DisplayConfigs { get; set; } = new List<SPGroupView_DisplayConfig>();

    public virtual ICollection<SPMatrixView_DisplayConfig> SPMatrixView_DisplayConfigs { get; set; } = new List<SPMatrixView_DisplayConfig>();
}
