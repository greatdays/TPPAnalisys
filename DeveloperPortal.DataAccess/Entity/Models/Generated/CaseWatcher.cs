using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CaseWatcher
{
    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseID { get; set; }

    /// <summary>
    /// User ID from IDM.
    /// </summary>
    public string WatcherID { get; set; } = null!;

    public virtual Case Case { get; set; } = null!;
}
