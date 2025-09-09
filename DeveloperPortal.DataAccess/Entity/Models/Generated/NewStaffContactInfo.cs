using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class NewStaffContactInfo
{
    public int NewStaffContactInfoId { get; set; }

    public int ProjSitePropSnapshotId { get; set; }

    public int LutAssociatedRoleId { get; set; }

    public int LutChangeRoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutAssociatedRole LutAssociatedRole { get; set; } = null!;

    public virtual LutChangeRole LutChangeRole { get; set; } = null!;

    public virtual PropSnapshot ProjSitePropSnapshot { get; set; } = null!;

    public virtual ICollection<QrnewStaffContactInfo> QrnewStaffContactInfos { get; set; } = new List<QrnewStaffContactInfo>();
}
