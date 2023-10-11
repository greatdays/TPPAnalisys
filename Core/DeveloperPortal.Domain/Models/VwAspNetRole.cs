using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwAspNetRole
{
    public int RoleId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsDefaultRole { get; set; }

    public int Priority { get; set; }
}
