using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutViolation
{
    public int LutViolationId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CodeLanguage { get; set; }

    public string? Remedy { get; set; }

    public bool IsFeeRequired { get; set; }

    public bool IsPermitRequired { get; set; }

    public string? VisualIndicator { get; set; }

    /// <summary>
    /// Obsolete yes or no
    /// </summary>
    public bool IsObsolete { get; set; }

    public int LutViolationCategoryId { get; set; }

    public string? SeverityLevelUnit { get; set; }

    public string? SeverityLevelBldg { get; set; }

    public string? SeverityLevelProp { get; set; }

    public string? Justification { get; set; }

    public bool IsRepeatable { get; set; }

    public bool IsResearchable { get; set; }

    public string? RefViolation { get; set; }

    public DateTime? EffectiveDate { get; set; }

    /// <summary>
    /// Created by which user
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created on which datetime
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified by which user
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified on which datetime
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public string? QuestionForm { get; set; }

    public string? QuestionNumber { get; set; }

    public string? DesiredInformation { get; set; }

    public virtual ICollection<AssnServiceRequestTypeViolation> AssnServiceRequestTypeViolations { get; set; } = new List<AssnServiceRequestTypeViolation>();

    public virtual ICollection<AssnViolationProgram> AssnViolationPrograms { get; set; } = new List<AssnViolationProgram>();

    public virtual ICollection<CannedNote> CannedNotes { get; set; } = new List<CannedNote>();

    public virtual LutViolationCategory LutViolationCategory { get; set; } = null!;

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();

    public virtual ICollection<LutLocationCategory> LutLocationCategories { get; set; } = new List<LutLocationCategory>();

    public virtual ICollection<LutViolationCode> LutViolationCodes { get; set; } = new List<LutViolationCode>();

    public virtual ICollection<LutViolationLocation> LutViolationLocations { get; set; } = new List<LutViolationLocation>();
}
