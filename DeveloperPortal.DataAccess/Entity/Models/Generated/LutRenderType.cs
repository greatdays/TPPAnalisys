using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutRenderType
{
    public int LutRenderTypeId { get; set; }

    public string RenderType { get; set; } = null!;

    public bool? IsAbsolute { get; set; }

    public bool? IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<SpgridViewDisplayConfig> SpgridViewDisplayConfigs { get; set; } = new List<SpgridViewDisplayConfig>();
}
