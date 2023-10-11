using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Documents config table
/// </summary>
public partial class DocumentsConfig
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? DivToRefresh { get; set; }

    public string? DocumentTypeJson { get; set; }

    public string? MethodToCall { get; set; }

    public string? HelpText { get; set; }

    public bool? IsEditable { get; set; }

    public bool? IsObsolate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }
}
