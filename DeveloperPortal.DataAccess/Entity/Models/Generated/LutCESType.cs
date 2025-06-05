using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutCestype
{
    public int LutCestypeId { get; set; }

    public string Cestype { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public string? DisplayText { get; set; }

    public int? SortOrder { get; set; }

    public string? DisplayTextPublic { get; set; }

    public virtual ICollection<PmpprojectSiteSnap> PmpprojectSiteSnaps { get; set; } = new List<PmpprojectSiteSnap>();

    public virtual ICollection<Pmpsnap> Pmpsnaps { get; set; } = new List<Pmpsnap>();

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
