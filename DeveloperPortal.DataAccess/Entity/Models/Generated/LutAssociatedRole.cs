using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutAssociatedRole
{
    public int LutAssociatedRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public int ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<NewStaffContactInfo> NewStaffContactInfos { get; set; } = new List<NewStaffContactInfo>();

    public virtual ICollection<QrnewStaffContactInfo> QrnewStaffContactInfos { get; set; } = new List<QrnewStaffContactInfo>();
}
