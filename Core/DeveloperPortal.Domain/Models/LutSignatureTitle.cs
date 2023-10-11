using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutSignatureTitle
{
    public int LutSignatureTitleId { get; set; }

    public string SignatureTitle { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ViewOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<FairHousing> FairHousings { get; set; } = new List<FairHousing>();

    public virtual ICollection<QrfairHousing> QrfairHousings { get; set; } = new List<QrfairHousing>();
}
