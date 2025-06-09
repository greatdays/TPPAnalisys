using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PmpagencySnap
{
    public int PmpagencySnapId { get; set; }

    public int PmpsnapId { get; set; }

    public int PmpagencyId { get; set; }

    public string? PmpagencyName { get; set; }

    public string? PmpagencyContactName { get; set; }

    public string? PmpagencyAddress { get; set; }

    public string? PmpagencyPhoneNumber { get; set; }

    public string? PmpagencyEmail { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual Pmpsnap Pmpsnap { get; set; } = null!;
}
