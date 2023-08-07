using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Policy compliance schedule meeting location and type
/// </summary>
public partial class AuditVisitDetail
{
    public int AuditVisitDetailId { get; set; }

    public int CaseId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? CaseLogId { get; set; }

    public string? VisitType { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public string ContactHistoryId { get; set; } = null!;

    public string? VisitLocation { get; set; }

    public string? LocationAddress { get; set; }

    public string? Comments { get; set; }

    public string? Reason { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public string? Attributes { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual CaseLog? CaseLog { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
