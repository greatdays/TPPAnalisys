using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnTeamManagementUser
{
    public int TeamManagementId { get; set; }

    public int UserId { get; set; }

    public virtual TeamManagement TeamManagement { get; set; } = null!;
}
