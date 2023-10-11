using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutImportantDate
{
    public int LutImportantDateId { get; set; }

    public string? EventName { get; set; }

    public string? EventDisplayName { get; set; }

    public bool IsEditable { get; set; }

    public int? ActionId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CaseTypeId { get; set; }

    public bool IsBackDateAllowed { get; set; }

    public bool IsMandatory { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual WfAction? Action { get; set; }

    public virtual CaseType? CaseType { get; set; }

    public virtual ICollection<ImportantDate> ImportantDates { get; set; } = new List<ImportantDate>();
}
