using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutApplicationType
{
    public int LutApplicationTypeID { get; set; }

    public string? ApplicationType { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AUWaitList> AUWaitLists { get; set; } = new List<AUWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitLists { get; set; } = new List<QRAUWaitList>();
}
