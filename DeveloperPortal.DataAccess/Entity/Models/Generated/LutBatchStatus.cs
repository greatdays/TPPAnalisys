using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutBatchStatus
{
    public int LutBatchStatusId { get; set; }

    public string BatchStatus { get; set; } = null!;

    public string? BatchApp { get; set; }

    public string? ExternStateCode { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public virtual ICollection<BatchJobDetail> BatchJobDetails { get; set; } = new List<BatchJobDetail>();

    public virtual ICollection<BatchJob> BatchJobs { get; set; } = new List<BatchJob>();
}
