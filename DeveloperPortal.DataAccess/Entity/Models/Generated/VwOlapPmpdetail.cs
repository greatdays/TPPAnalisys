using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwOlapPmpdetail
{
    public int ProjectSiteId { get; set; }

    public int PropSnapshotId { get; set; }

    public bool? IsCovered { get; set; }

    public int CaseId { get; set; }

    public long ServiceRequestId { get; set; }

    public string? ServiceRequestNumber { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string OwnerOrLegalEntityName { get; set; } = null!;

    public string PmplogStatus { get; set; } = null!;

    public int? ProjectId { get; set; }
}
