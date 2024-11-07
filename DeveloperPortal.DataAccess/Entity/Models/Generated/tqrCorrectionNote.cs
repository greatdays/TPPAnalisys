using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class tqrCorrectionNote
{
    public int QRCorrectionNoteID { get; set; }

    public int? QuarterlyReportID { get; set; }

    public int? PropSnapShotID { get; set; }

    public string? CorrectionNote { get; set; }

    public bool IsCorrected { get; set; }

    public bool IsSubmitted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
