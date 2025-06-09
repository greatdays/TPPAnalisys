using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CannedNote
{
    public int CannedNoteId { get; set; }

    public int LutViolationId { get; set; }

    public int LutViolationLocationId { get; set; }

    public string Note { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public bool? IsStandard { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutViolation LutViolation { get; set; } = null!;

    public virtual LutViolationLocation LutViolationLocation { get; set; } = null!;
}
