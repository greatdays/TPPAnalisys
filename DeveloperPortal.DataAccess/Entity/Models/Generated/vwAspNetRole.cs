using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAspNetRole
{
    public int RoleId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsDefaultRole { get; set; }

    public int Priority { get; set; }
}
