using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// View Configuration for SSRSViewer Control.
/// </summary>
public partial class ViewConfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of this configuration. This name should be unique for given type of control.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Name or title to be displayed during rendering of this control. If not specified, blank title will be displayed.
    /// </summary>
    public string? DisplayName { get; set; }
}
