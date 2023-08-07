using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutDocumentTag
{
    public int LutDocumentTagId { get; set; }

    public string DocumentTag { get; set; } = null!;

    public string? DocumentTagCd { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }
}
