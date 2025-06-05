using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnUserContractor
{
    public int UserId { get; set; }

    public string? ContractorName { get; set; }

    public string? PhoneNo { get; set; }

    public string? License { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Email { get; set; }

    public DateTime? DateAffectCert { get; set; }

    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
