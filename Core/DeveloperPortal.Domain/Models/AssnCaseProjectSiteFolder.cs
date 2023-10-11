using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnCaseProjectSiteFolder
{
    public int CaseId { get; set; }

    public int ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? FolderName { get; set; }

    public string? FolderId { get; set; }

    public string? FolderLink { get; set; }

    public string? FolderJson { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }
}
