using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutImportantDate
{
    public int LutImportantDateID { get; set; }

    public string? EventName { get; set; }

    public string? EventDisplayName { get; set; }

    public bool IsEditable { get; set; }

    public int? ActionID { get; set; }

    public bool IsDeleted { get; set; }

    public int? CaseTypeID { get; set; }

    public bool IsBackDateAllowed { get; set; }

    public bool IsMandatory { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ViewOrder { get; set; }

    public virtual WF_Action? Action { get; set; }

    public virtual CaseType? CaseType { get; set; }

    public virtual ICollection<ImportantDate> ImportantDates { get; set; } = new List<ImportantDate>();
}
