using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutApplicationType
{
    public int LutApplicationTypeId { get; set; }

    public string? ApplicationType { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AuwaitList> AuwaitLists { get; set; } = new List<AuwaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitLists { get; set; } = new List<QrauwaitList>();
}
