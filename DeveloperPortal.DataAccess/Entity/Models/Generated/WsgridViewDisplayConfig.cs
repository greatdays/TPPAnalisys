using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WsgridViewDisplayConfig
{
    public int Id { get; set; }

    public int? WsconfigId { get; set; }

    public string Name { get; set; } = null!;

    public string ParamNamenValue { get; set; } = null!;

    public int? NoOfRecords { get; set; }

    public bool IsCollapsed { get; set; }

    public bool IsPaging { get; set; }

    public bool IsSearch { get; set; }

    public int? RecordsPerPage { get; set; }

    public bool IsViewAll { get; set; }

    public string? ViewAllUrl { get; set; }

    public bool IsExportPdf { get; set; }

    public bool IsExportExcel { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual WsviewWsconfig? Wsconfig { get; set; }

    public virtual ICollection<WsgridViewColumnConfig> WsgridViewColumnConfigs { get; set; } = new List<WsgridViewColumnConfig>();
}
