using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutSiteSurveyGroup
{
    public int LutSiteSurveyGroupId { get; set; }

    public string SiteSurveyGroup { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }
}
