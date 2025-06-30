using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutRacategory
{
    public int LutRacategoryId { get; set; }

    public int LutRarequestTypeId { get; set; }

    public string Racategory { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual LutRarequestType LutRarequestType { get; set; } = null!;

    public virtual ICollection<LutRasubCategory> LutRasubCategories { get; set; } = new List<LutRasubCategory>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();
}
