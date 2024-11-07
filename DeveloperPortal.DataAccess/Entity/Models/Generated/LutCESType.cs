using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutCESType
{
    public int LutCESTypeID { get; set; }

    public string CESType { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public string? DisplayText { get; set; }

    public int? SortOrder { get; set; }

    public string? DisplayTextPublic { get; set; }

    public virtual ICollection<PMPProjectSiteSnap> PMPProjectSiteSnaps { get; set; } = new List<PMPProjectSiteSnap>();

    public virtual ICollection<PMPSnap> PMPSnaps { get; set; } = new List<PMPSnap>();

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
