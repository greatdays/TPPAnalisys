using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutTemplate1
{
    public int LutTemplateId { get; set; }

    public string? TemplateName { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<EnforcementOrderReviewDetail> EnforcementOrderReviewDetails { get; set; } = new List<EnforcementOrderReviewDetail>();
}
