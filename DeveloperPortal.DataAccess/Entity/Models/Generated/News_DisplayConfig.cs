using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class News_DisplayConfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? NoOfRecordsInList { get; set; }

    public int? NoOfRecordsInAllList { get; set; }

    public int? SummaryCharLimit { get; set; }

    public bool? IsDisplayDate { get; set; }

    public string? DateToDisplay { get; set; }

    public bool? IsDisplaySubmittedBy { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual ICollection<News_NewsDetail> News_NewsDetails { get; set; } = new List<News_NewsDetail>();
}
