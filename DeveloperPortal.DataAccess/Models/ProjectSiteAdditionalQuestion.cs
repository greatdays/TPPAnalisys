using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

/// <summary>
/// To save the additional questions added by owner/pm for property which will be asked while application
/// </summary>
public partial class ProjectSiteAdditionalQuestion
{
    public int ProjectSiteAddQuestionId { get; set; }

    public int? ProjectSiteAttributeId { get; set; }

    public string? Question { get; set; }

    public string? Guid { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ProjectSiteAttribute? ProjectSiteAttribute { get; set; }
}
