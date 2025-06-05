using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGmcheckList
{
    public int LutGmcheckListId { get; set; }

    public string? Category { get; set; }

    public string? Role { get; set; }

    public string? Question { get; set; }

    public Guid? ApplicationGuid { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ServiceRequestGmcheckList> ServiceRequestGmcheckLists { get; set; } = new List<ServiceRequestGmcheckList>();
}
