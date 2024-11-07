using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnProjectSiteQuestion
{
    public int AssnProjectSiteQuestionID { get; set; }

    public int ProjectSiteAttributeID { get; set; }

    public int LutProjectSiteQuestionID { get; set; }

    public string? SpecialNote { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutProjectSiteQuestion LutProjectSiteQuestion { get; set; } = null!;

    public virtual ProjectSiteAttribute ProjectSiteAttribute { get; set; } = null!;
}
