using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class CaseType
{
    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseTypeId { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Work flow Definition
    /// </summary>
    public int? WfDefinitionId { get; set; }

    /// <summary>
    /// Is Obsolete flag
    /// </summary>
    public bool IsObsolete { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();

    public virtual ICollection<LutImportantDate> LutImportantDates { get; set; } = new List<LutImportantDate>();

    public virtual WfDefinition? WfDefinition { get; set; }

    public virtual ICollection<ApplicationMaster> ApplicationMasters { get; set; } = new List<ApplicationMaster>();

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
}
