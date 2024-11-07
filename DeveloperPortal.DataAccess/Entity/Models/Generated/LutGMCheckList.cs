using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutGMCheckList
{
    public int LutGMCheckListID { get; set; }

    public string? Category { get; set; }

    public string? Role { get; set; }

    public string? Question { get; set; }

    public Guid? ApplicationGUID { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ServiceRequestGMCheckList> ServiceRequestGMCheckLists { get; set; } = new List<ServiceRequestGMCheckList>();
}
