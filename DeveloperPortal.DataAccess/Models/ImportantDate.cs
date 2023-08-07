using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class ImportantDate
{
    public int ImportantDateId { get; set; }

    public int? LutImportantDateId { get; set; }

    public DateTime? Date { get; set; }

    public long? ServiceRequestId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutImportantDate? LutImportantDate { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
