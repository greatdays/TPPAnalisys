using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class SpviewSpconfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to SPView_DBConfiguration table
    /// </summary>
    public int DbconfigId { get; set; }

    /// <summary>
    /// This field is used to store stored procedure name which is exists on selected database server.
    /// </summary>
    public string Spname { get; set; } = null!;

    public virtual SpviewDbconfig Dbconfig { get; set; } = null!;

    public virtual ICollection<SpdetailViewColumnConfig> SpdetailViewColumnConfigs { get; set; } = new List<SpdetailViewColumnConfig>();

    public virtual ICollection<SpdetailViewDisplayConfig> SpdetailViewDisplayConfigs { get; set; } = new List<SpdetailViewDisplayConfig>();

    public virtual ICollection<SpgridViewColumnConfig> SpgridViewColumnConfigs { get; set; } = new List<SpgridViewColumnConfig>();

    public virtual ICollection<SpgridViewDisplayConfig> SpgridViewDisplayConfigs { get; set; } = new List<SpgridViewDisplayConfig>();

    public virtual ICollection<SpgroupViewColumnConfig> SpgroupViewColumnConfigs { get; set; } = new List<SpgroupViewColumnConfig>();

    public virtual ICollection<SpgroupViewDisplayConfig> SpgroupViewDisplayConfigs { get; set; } = new List<SpgroupViewDisplayConfig>();

    public virtual ICollection<SpmatrixViewDisplayConfig> SpmatrixViewDisplayConfigs { get; set; } = new List<SpmatrixViewDisplayConfig>();
}
