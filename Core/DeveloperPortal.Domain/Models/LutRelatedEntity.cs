using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutRelatedEntity
{
    public int LutRelatedEntityId { get; set; }

    public string? RelatedEntityName { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? RowId { get; set; }

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
}
