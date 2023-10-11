using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnRentalSubsidy
{
    public int AssnRentalSubsidyId { get; set; }

    public int PropSnapshotId { get; set; }

    public int LutRentalSubsidyId { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
