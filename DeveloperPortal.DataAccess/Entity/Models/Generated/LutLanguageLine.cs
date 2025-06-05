using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutLanguageLine
{
    public int LutLanguageLineId { get; set; }

    public string LanguageLine { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsAbsolute { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<PhoneLog> PhoneLogs { get; set; } = new List<PhoneLog>();
}
