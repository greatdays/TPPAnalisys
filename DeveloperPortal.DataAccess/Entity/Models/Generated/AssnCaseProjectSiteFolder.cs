using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnCaseProjectSiteFolder
{
    public int CaseID { get; set; }

    public int ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public string? FolderName { get; set; }

    public string? FolderID { get; set; }

    public string? FolderLink { get; set; }

    public string? FolderJSON { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectSite? ProjectSite { get; set; }
}
