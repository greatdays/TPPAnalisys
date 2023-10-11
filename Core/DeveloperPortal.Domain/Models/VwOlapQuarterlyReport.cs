using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapQuarterlyReport
{
    public int QuarterlyReportId { get; set; }

    public long? ServiceRequestId { get; set; }

    public int? PropSnapShotId { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? Year { get; set; }

    public string? Quarter { get; set; }

    public string? QrsubmittedBy { get; set; }

    public DateTime? QrsubmittedOn { get; set; }

    public DateTime? QrreviwedBy { get; set; }

    public DateTime? QrreviwedOn { get; set; }

    public DateTime QrcreatedOn { get; set; }

    public string Status { get; set; } = null!;

    public string? Action { get; set; }

    public bool? IsCovered { get; set; }
}
