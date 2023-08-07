using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Table holds Inspection Requests.
/// </summary>
public partial class InspectionScheduled
{
    public int InspectionRequestId { get; set; }

    public int CaseId { get; set; }

    public long ServiceRequestId { get; set; }

    public int? LutInspectionTypeId { get; set; }

    public DateTime? ScheduledOn { get; set; }

    public DateTime? ScheduledStartOn { get; set; }

    public DateTime? ScheduledEndOn { get; set; }

    public string? ServiceTrackingId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual ICollection<InspectionHistory> InspectionHistories { get; set; } = new List<InspectionHistory>();

    public virtual ICollection<InspectionNotification> InspectionNotifications { get; set; } = new List<InspectionNotification>();

    public virtual LutInspectionType? LutInspectionType { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
