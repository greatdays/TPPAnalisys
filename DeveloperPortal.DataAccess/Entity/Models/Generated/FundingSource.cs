using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class FundingSource
{
    public int FundingSourceId { get; set; }

    public string? FundingSourceName { get; set; }

    public int? MuUnit { get; set; }

    public int? HvUnit { get; set; }

    public int? DocumentId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Document? Document { get; set; }
}
