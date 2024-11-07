using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnFairHousingCertifyTerm
{
    public int AssnFairHousingCertifyTermsID { get; set; }

    public int FairHousingID { get; set; }

    public int LutQRCertifyTermsID { get; set; }

    public bool? IsAccepted { get; set; }

    public virtual FairHousing FairHousing { get; set; } = null!;

    public virtual LutQRCertifyTerm LutQRCertifyTerms { get; set; } = null!;
}
