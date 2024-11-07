using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutRARequestType
{
    public int LutRARequestTypeID { get; set; }

    public int LutUserTypeID { get; set; }

    public string RARequestType { get; set; } = null!;

    public int ViewOrder { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<LutRACategory> LutRACategories { get; set; } = new List<LutRACategory>();

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();
}
