using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TeamManagement
{
    public int TeamManagementId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AssnTeamManagementUser> AssnTeamManagementUsers { get; set; } = new List<AssnTeamManagementUser>();
}
