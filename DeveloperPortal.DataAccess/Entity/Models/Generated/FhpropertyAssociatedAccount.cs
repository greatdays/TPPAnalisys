using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class FhpropertyAssociatedAccount
{
    public int FhpropertyAssociatedAccountsId { get; set; }

    public int FairHousingId { get; set; }

    public int ProjectSitePropSnapShotId { get; set; }

    public int? ContactIdentifierId { get; set; }

    public string ContactName { get; set; } = null!;

    public int LutContactTypeId { get; set; }

    public string ContactType { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? CertificationDate { get; set; }

    public DateOnly? NextEnrolledFhtrainingDate { get; set; }

    public virtual FairHousing FairHousing { get; set; } = null!;

    public virtual LutContactType LutContactType { get; set; } = null!;

    public virtual PropSnapshot ProjectSitePropSnapShot { get; set; } = null!;
}
