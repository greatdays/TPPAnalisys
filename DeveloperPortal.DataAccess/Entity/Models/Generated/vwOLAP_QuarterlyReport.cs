using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_QuarterlyReport
{
    public int QuarterlyReportID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int? PropSnapShotID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? Year { get; set; }

    public string? Quarter { get; set; }

    public string? QRSubmittedBy { get; set; }

    public DateTime? QRSubmittedOn { get; set; }

    public DateTime? QRReviwedBy { get; set; }

    public DateTime? QRReviwedOn { get; set; }

    public DateTime QRCreatedOn { get; set; }

    public string Status { get; set; } = null!;

    public string? Action { get; set; }

    public bool? IsCovered { get; set; }
}
