using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WorkExtension
{
    public int WorkExtensionId { get; set; }

    public long ServiceRequestId { get; set; }

    public int InspectionId { get; set; }

    public int? ExtensionDays { get; set; }

    public int? ApprovedDays { get; set; }

    public string? PreferredDay { get; set; }

    public string? ApprovedDay { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Inspection Inspection { get; set; } = null!;

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
