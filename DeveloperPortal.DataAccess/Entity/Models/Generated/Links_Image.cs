using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Links_Image
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This field is used to store icon Image name.
    /// </summary>
    public string ImageName { get; set; } = null!;

    public int? ParentId { get; set; }

    /// <summary>
    /// This field is used to store icon Image height.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// This field is used to store icon Image width.
    /// </summary>
    public int? Width { get; set; }

    public virtual ICollection<Links_Image> InverseParent { get; set; } = new List<Links_Image>();

    public virtual ICollection<Links_DisplayConfig> Links_DisplayConfigs { get; set; } = new List<Links_DisplayConfig>();

    public virtual ICollection<Links_LinkDetail> Links_LinkDetails { get; set; } = new List<Links_LinkDetail>();

    public virtual Links_Image? Parent { get; set; }
}
