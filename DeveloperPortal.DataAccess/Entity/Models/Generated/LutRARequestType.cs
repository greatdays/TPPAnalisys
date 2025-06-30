using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutRarequestType
{
    public int LutRarequestTypeId { get; set; }

    public int LutUserTypeId { get; set; }

    public string RarequestType { get; set; } = null!;

    public int ViewOrder { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<LutRacategory> LutRacategories { get; set; } = new List<LutRacategory>();

    public virtual LutUserType LutUserType { get; set; } = null!;

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();
}
