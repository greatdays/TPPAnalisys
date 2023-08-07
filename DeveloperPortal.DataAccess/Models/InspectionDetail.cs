using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class InspectionDetail
{
    public int InspectionDetailId { get; set; }

    public int InspectionId { get; set; }

    public int PropSnapshotId { get; set; }

    public DateTime? InspectedOn { get; set; }

    public DateTime? InspectedStartOn { get; set; }

    public DateTime? InspectedEndOn { get; set; }

    public string? InspectionResult { get; set; }

    public string? ServiceTrackingId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
