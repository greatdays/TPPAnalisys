using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Ccdetail
{
    public int CcdetailsId { get; set; }

    public long? ServiceRequestId { get; set; }

    public bool? IsPmpavailable { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CloseReason { get; set; }

    public string? NacInspectionReason { get; set; }

    public DateTime? DateCityCertifiedCsa { get; set; }

    public DateTime? DateCityCertifiedVca { get; set; }

    public DateTime? DateNacissuedVerificationCsa { get; set; }

    public DateTime? DateNacissuedVerificationVca { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
