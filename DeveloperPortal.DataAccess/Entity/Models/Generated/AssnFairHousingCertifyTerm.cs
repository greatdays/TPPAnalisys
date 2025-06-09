using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnFairHousingCertifyTerm
{
    public int AssnFairHousingCertifyTermsId { get; set; }

    public int FairHousingId { get; set; }

    public int LutQrcertifyTermsId { get; set; }

    public bool? IsAccepted { get; set; }

    public virtual FairHousing FairHousing { get; set; } = null!;

    public virtual LutQrcertifyTerm LutQrcertifyTerms { get; set; } = null!;
}
