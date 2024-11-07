using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class CCDetail
{
    public int CCDetailsID { get; set; }

    public long? ServiceRequestID { get; set; }

    public bool? IsPMPAvailable { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CloseReason { get; set; }

    public string? NacInspectionReason { get; set; }

    public DateOnly? DateCityCertifiedCSA { get; set; }

    public DateOnly? DateCityCertifiedVCA { get; set; }

    public DateOnly? DateNACIssuedVerificationCSA { get; set; }

    public DateOnly? DateNACIssuedVerificationVCA { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
