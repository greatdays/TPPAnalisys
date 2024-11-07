using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Table holds Inspections.
/// </summary>
public partial class Inspection
{
    public int InspectionID { get; set; }

    public int? PropSnapshotID { get; set; }

    public int? LocationID { get; set; }

    public long ServiceRequestID { get; set; }

    public int? LutInspectionTypeID { get; set; }

    public DateTime? InspectedOn { get; set; }

    public DateTime? InspectedStartOn { get; set; }

    public DateTime? InspectedEndOn { get; set; }

    public string? InspectionResult { get; set; }

    public string? ServiceTrackingID { get; set; }

    public int? EventID { get; set; }

    public int? MainInspectionID { get; set; }

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
