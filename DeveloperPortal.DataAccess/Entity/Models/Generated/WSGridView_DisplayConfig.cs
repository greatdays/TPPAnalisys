using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WSGridView_DisplayConfig
{
    public int Id { get; set; }

    public int? WSConfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int? NoOfRecords { get; set; }

    public bool IsCollapsed { get; set; }

    public bool IsPaging { get; set; }

    public bool IsSearch { get; set; }

    public int? RecordsPerPage { get; set; }

    public bool IsViewAll { get; set; }

    public string? ViewAllURL { get; set; }

    public bool IsExportPDF { get; set; }

    public bool IsExportExcel { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WSView_WSConfig? WSConfig { get; set; }

    public virtual ICollection<WSGridView_ColumnConfig> WSGridView_ColumnConfigs { get; set; } = new List<WSGridView_ColumnConfig>();
}
