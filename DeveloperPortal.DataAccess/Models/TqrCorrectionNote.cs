using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TqrCorrectionNote
{
    public int QrcorrectionNoteId { get; set; }

    public int? QuarterlyReportId { get; set; }

    public int? PropSnapShotId { get; set; }

    public string? CorrectionNote { get; set; }

    public bool IsCorrected { get; set; }

    public bool IsSubmitted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
