using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutDeniedConsentUserType
{
    public int LutDeniedConsentUserTypeId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
