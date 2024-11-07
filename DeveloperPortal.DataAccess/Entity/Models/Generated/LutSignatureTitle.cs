using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutSignatureTitle
{
    public int LutSignatureTitleID { get; set; }

    public string SignatureTitle { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<FairHousing> FairHousings { get; set; } = new List<FairHousing>();

    public virtual ICollection<QRFairHousing> QRFairHousings { get; set; } = new List<QRFairHousing>();
}
