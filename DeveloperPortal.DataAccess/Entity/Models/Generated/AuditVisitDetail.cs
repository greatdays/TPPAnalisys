using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Policy compliance schedule meeting location and type
/// </summary>
public partial class AuditVisitDetail
{
    public int AuditVisitDetailID { get; set; }

    public int CaseID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int? CaseLogID { get; set; }

    public string? VisitType { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public string ContactHistoryID { get; set; } = null!;

    public string? VisitLocation { get; set; }

    public string? LocationAddress { get; set; }

    public string? Comments { get; set; }

    public string? Reason { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public string? Attributes { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual CaseLog? CaseLog { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
