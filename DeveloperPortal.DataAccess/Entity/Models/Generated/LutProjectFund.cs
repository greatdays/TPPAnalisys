using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutProjectFund
{
    public int LutProjectFundId { get; set; }

    public string FundCode { get; set; } = null!;

    public string? FundDescription { get; set; }

    public bool? IsPrefix { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
