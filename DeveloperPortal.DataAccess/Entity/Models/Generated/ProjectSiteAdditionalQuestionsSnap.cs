using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// To save snap for table projectSiteAddtionalQuestions when listing published
/// </summary>
public partial class ProjectSiteAdditionalQuestionsSnap
{
    public int ProjectSiteAddQuestionSnapId { get; set; }

    public int? ProjectSiteSnapId { get; set; }

    public string? Question { get; set; }

    public string? Guid { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ProjectSiteSnap? ProjectSiteSnap { get; set; }
}
