using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Form
{
    public int FormId { get; set; }

    public int ApplicationMasterId { get; set; }

    public string FormName { get; set; } = null!;

    public string FormType { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public string? RedirectPage { get; set; }

    public bool IsEmail { get; set; }

    public int? ActionSchemaTemplateId { get; set; }

    public int? LutRelatedEntityId { get; set; }

    public string? GetApiUrl { get; set; }

    public string? PostApiUrl { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? RowId { get; set; }

    public string? PredefinedPostColumn { get; set; }

    public virtual ApplicationMaster ApplicationMaster { get; set; } = null!;

    public virtual ICollection<Field> Fields { get; set; } = new List<Field>();

    public virtual LutRelatedEntity? LutRelatedEntity { get; set; }

    public virtual ICollection<CaseType> CaseTypes { get; set; } = new List<CaseType>();
}
