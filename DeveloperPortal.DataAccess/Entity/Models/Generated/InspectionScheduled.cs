using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Table holds Inspection Requests.
/// </summary>
public partial class InspectionScheduled
{
    public int InspectionRequestID { get; set; }

    public int CaseID { get; set; }

    public long ServiceRequestID { get; set; }

    public int? LutInspectionTypeID { get; set; }

    public DateTime? ScheduledOn { get; set; }

    public DateTime? ScheduledStartOn { get; set; }

    public DateTime? ScheduledEndOn { get; set; }

    public string? ServiceTrackingID { get; set; }

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
