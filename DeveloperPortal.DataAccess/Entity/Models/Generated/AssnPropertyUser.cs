using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnPropertyUser
{
    public int LutPropertyDistrictId { get; set; }

    public string? Idmuser { get; set; }

    public string? AssociationType { get; set; }

    public string? AssociatedFrom { get; set; }

    public string? AssociatedTo { get; set; }

    public bool? ReviewRequired { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
