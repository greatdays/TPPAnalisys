using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutOccupancyStatus
{
    public int LutOccupancyStatusId { get; set; }

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ProjectSite> ProjectSites { get; set; } = new List<ProjectSite>();
}
