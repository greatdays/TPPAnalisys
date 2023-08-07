using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AssnRentalSubsidySnap
{
    public int AssnRentalSubsidySnapId { get; set; }

    public int UnitSnapId { get; set; }

    public int UnitAttributeId { get; set; }

    public int LutRentalSubsidyId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual UnitSnap UnitSnap { get; set; } = null!;
}
