using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class CaseWatcher
{
    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseId { get; set; }

    /// <summary>
    /// User ID from IDM.
    /// </summary>
    public string WatcherId { get; set; } = null!;

    public virtual Case Case { get; set; } = null!;
}
