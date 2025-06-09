using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutReferenceType
{
    public int LutReferenceTypeId { get; set; }

    public string? ReferenceType { get; set; }

    public bool? IsObsolete { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnProjectSiteReference> AssnProjectSiteReferences { get; set; } = new List<AssnProjectSiteReference>();
}
