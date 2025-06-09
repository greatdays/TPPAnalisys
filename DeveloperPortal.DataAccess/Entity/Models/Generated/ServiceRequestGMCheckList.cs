using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ServiceRequestGmcheckList
{
    public int SrgmcheckListId { get; set; }

    public long ServiceRequestId { get; set; }

    public int LutGmcheckListId { get; set; }

    public string? Answer { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutGmcheckList LutGmcheckList { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
