using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_PMPDetail
{
    public int ProjectSiteID { get; set; }

    public int PropSnapshotID { get; set; }

    public bool? IsCovered { get; set; }

    public int caseID { get; set; }

    public long ServiceRequestID { get; set; }

    public string? ServiceRequestNumber { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string OwnerOrLegalEntityName { get; set; } = null!;

    public string PMPLogStatus { get; set; } = null!;

    public int? ProjectID { get; set; }
}
