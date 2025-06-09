using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutBatchType
{
    public int LutBatchTypeId { get; set; }

    public string BatchType { get; set; } = null!;

    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public virtual ICollection<BatchJob> BatchJobs { get; set; } = new List<BatchJob>();
}
