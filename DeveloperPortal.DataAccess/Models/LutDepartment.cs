using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutDepartment
{
    public int LutDepartmentId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;
}
