using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutRentalSubsidy
{
    public int LutRentalSubsidyId { get; set; }

    public string? RentalSubsidy { get; set; }

    public bool IsObsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnQrrentalSubsidy> AssnQrrentalSubsidies { get; set; } = new List<AssnQrrentalSubsidy>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnits { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<UnitAttribute> UnitAttributes { get; set; } = new List<UnitAttribute>();
}
