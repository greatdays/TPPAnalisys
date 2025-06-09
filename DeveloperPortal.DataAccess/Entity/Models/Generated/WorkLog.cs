using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WorkLog
{
    public int WorkLogId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? LutWorkLogTypeId { get; set; }

    public string? Description { get; set; }

    public bool? IsObsolete { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutWorkLogType1? LutWorkLogType { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
