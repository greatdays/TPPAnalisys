using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class LutNoticeType
{
    public int LutNoticeTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool IsObsolete { get; set; }

    /// <summary>
    /// Created by which user
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Created on which datetime
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// Modified by which user
    /// </summary>
    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
}
