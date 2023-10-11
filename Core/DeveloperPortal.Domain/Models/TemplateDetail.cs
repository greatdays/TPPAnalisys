using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// This table is used for to store template detail in form of row and number of column that template have. Each row have 1 or more columns and column increase in multiple of 2 i.e. 2,4,6...12. Max column width is 12.
/// </summary>
public partial class TemplateDetail
{
    public int TemplateDetailId { get; set; }

    public int? TemplateId { get; set; }

    public int? ColumnNumber { get; set; }

    public int? RowNumber { get; set; }

    public int? ColumnWidth { get; set; }

    public int? ColumnHeight { get; set; }

    public string? RenderSection { get; set; }

    public virtual TemplateMaster? Template { get; set; }
}
