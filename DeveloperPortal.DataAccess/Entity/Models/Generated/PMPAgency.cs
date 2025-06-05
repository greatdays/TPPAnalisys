using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Pmpagency
{
    public int PmpagencyId { get; set; }

    public string? PmpagencyName { get; set; }

    public string? PmpagencyContactName { get; set; }

    public string? PmpagencyAddress { get; set; }

    public string? PmpagencyPhoneNumber { get; set; }

    public string? PmpagencyEmail { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnPmpagency> AssnPmpagencies { get; set; } = new List<AssnPmpagency>();
}
