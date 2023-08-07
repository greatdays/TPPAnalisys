using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// Table holds Inspections.
/// </summary>
public partial class Inspection
{
    public int InspectionId { get; set; }

    public int? PropSnapshotId { get; set; }

    public int? LocationId { get; set; }

    public long ServiceRequestId { get; set; }

    public int? LutInspectionTypeId { get; set; }

    public DateTime? InspectedOn { get; set; }

    public DateTime? InspectedStartOn { get; set; }

    public DateTime? InspectedEndOn { get; set; }

    public string? InspectionResult { get; set; }

    public string? ServiceTrackingId { get; set; }

    public int? EventId { get; set; }

    public int? MainInspectionId { get; set; }

    public string? Attributes { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnInspectionViolation> AssnInspectionViolations { get; set; } = new List<AssnInspectionViolation>();

    public virtual ICollection<Extension> Extensions { get; set; } = new List<Extension>();

    public virtual ICollection<InspectionHistory> InspectionHistories { get; set; } = new List<InspectionHistory>();

    public virtual ICollection<InspectionNotification> InspectionNotifications { get; set; } = new List<InspectionNotification>();

    public virtual Location? Location { get; set; }

    public virtual LutInspectionType? LutInspectionType { get; set; }

    public virtual PropSnapshot? PropSnapshot { get; set; }

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;

    public virtual ICollection<WarrantDetail> WarrantDetails { get; set; } = new List<WarrantDetail>();

    public virtual ICollection<WorkExtension> WorkExtensions { get; set; } = new List<WorkExtension>();
}
