using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class DocumentTemplate
{
    public int DocumentTemplateId { get; set; }

    public int? LutTemplateId { get; set; }

    public string? Tmsname { get; set; }

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual LutTemplate? LutTemplate { get; set; }
}
