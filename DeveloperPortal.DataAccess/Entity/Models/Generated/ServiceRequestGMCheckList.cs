using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ServiceRequestGMCheckList
{
    public int SRGMCheckListID { get; set; }

    public long ServiceRequestID { get; set; }

    public int LutGMCheckListID { get; set; }

    public string? Answer { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutGMCheckList LutGMCheckList { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
