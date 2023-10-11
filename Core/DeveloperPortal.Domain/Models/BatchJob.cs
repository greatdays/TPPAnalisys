using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class BatchJob
{
    public int BatchJobId { get; set; }

    public string? BatchNo { get; set; }

    public int LutBatchTypeId { get; set; }

    public int LutBatchStatusId { get; set; }

    public string? OutputName { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public string? BatchJobAttributes { get; set; }

    public virtual ICollection<BatchJobDetail> BatchJobDetails { get; set; } = new List<BatchJobDetail>();

    public virtual LutBatchStatus LutBatchStatus { get; set; } = null!;

    public virtual LutBatchType LutBatchType { get; set; } = null!;
}
