using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class InspectionDetail
{
    public int InspectionDetailID { get; set; }

    public int InspectionID { get; set; }

    public int PropSnapshotID { get; set; }

    public DateTime? InspectedOn { get; set; }

    public DateTime? InspectedStartOn { get; set; }

    public DateTime? InspectedEndOn { get; set; }

    public string? InspectionResult { get; set; }

    public string? ServiceTrackingID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
