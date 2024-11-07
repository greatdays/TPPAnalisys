using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class ImportantDate
{
    public int ImportantDateID { get; set; }

    public int? LutImportantDateID { get; set; }

    public DateTime? Date { get; set; }

    public long? ServiceRequestID { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutImportantDate? LutImportantDate { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
