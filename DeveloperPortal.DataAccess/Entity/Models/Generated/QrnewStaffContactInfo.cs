using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QrnewStaffContactInfo
{
    public int QrnewStaffContactInfoId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int NewStaffContactInfoId { get; set; }

    public int LutAssociatedRoleId { get; set; }

    public int LutChangeRoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutAssociatedRole LutAssociatedRole { get; set; } = null!;

    public virtual LutChangeRole LutChangeRole { get; set; } = null!;

    public virtual NewStaffContactInfo NewStaffContactInfo { get; set; } = null!;

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
