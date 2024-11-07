using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CorrectionNote
{
    public int CorrectionNotesID { get; set; }

    public long? ServiceRequestID { get; set; }

    public int ProjSitePropSnapShotID { get; set; }

    public string Section { get; set; } = null!;

    public string CorrectionNote1 { get; set; } = null!;

    public bool IsSubmited { get; set; }

    public bool? IsSubmittedByOPM { get; set; }

    public bool IsCorrected { get; set; }

    public bool IsAllowEdit { get; set; }

    public bool IsAllowDelete { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsAcHP { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual PropSnapshot ProjSitePropSnapShot { get; set; } = null!;

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
