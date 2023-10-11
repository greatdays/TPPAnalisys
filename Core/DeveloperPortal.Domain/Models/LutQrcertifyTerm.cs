using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutQrcertifyTerm
{
    public int LutQrcertifyTermsId { get; set; }

    public string QrcertifyTerms { get; set; } = null!;

    public bool? IsAcceptMandatory { get; set; }

    public bool? IsMandatory { get; set; }

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public int? SortOrder { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AssnFairHousingCertifyTerm> AssnFairHousingCertifyTerms { get; set; } = new List<AssnFairHousingCertifyTerm>();

    public virtual ICollection<AssnQrfairHousingCertifyTerm> AssnQrfairHousingCertifyTerms { get; set; } = new List<AssnQrfairHousingCertifyTerm>();
}
