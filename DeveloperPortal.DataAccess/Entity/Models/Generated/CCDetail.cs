using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

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

    public DateOnly? DateCityCertifiedCsa { get; set; }

    public DateOnly? DateCityCertifiedVca { get; set; }

    public DateOnly? DateNacissuedVerificationCsa { get; set; }

    public DateOnly? DateNacissuedVerificationVca { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
