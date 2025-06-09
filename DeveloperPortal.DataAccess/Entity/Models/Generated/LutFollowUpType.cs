using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutFollowUpType
{
    public int LutFollowUpTypeId { get; set; }

    public string FollowUpType { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<BackgroundCheck> BackgroundChecks { get; set; } = new List<BackgroundCheck>();
}
