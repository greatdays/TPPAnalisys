using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnRentalSubsidySnap
{
    public int AssnRentalSubsidySnapID { get; set; }

    public int UnitSnapID { get; set; }

    public int UnitAttributeID { get; set; }

    public int LutRentalSubsidyID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual UnitSnap UnitSnap { get; set; } = null!;
}
