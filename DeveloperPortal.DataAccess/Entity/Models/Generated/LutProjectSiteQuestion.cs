using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutProjectSiteQuestion
{
    public int LutProjectSiteQuestionId { get; set; }

    public string Question { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public bool IsCheck { get; set; }

    public bool IsShowSpecialNotes { get; set; }

    public bool IsAlwaysSelected { get; set; }

    public int? ViewOrder { get; set; }

    public bool IsObsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnHrmapplicationPropQuestion> AssnHrmapplicationPropQuestions { get; set; } = new List<AssnHrmapplicationPropQuestion>();

    public virtual ICollection<AssnProjectSiteQuestion> AssnProjectSiteQuestions { get; set; } = new List<AssnProjectSiteQuestion>();
}
