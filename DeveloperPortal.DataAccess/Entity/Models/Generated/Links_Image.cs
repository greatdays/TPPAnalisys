using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Links_Images
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

    public virtual ICollection<Links_Images> InverseParent { get; set; } = new List<Links_Images>();

    public virtual ICollection<Links_DisplayConfig> Links_DisplayConfigs { get; set; } = new List<Links_DisplayConfig>();

    public virtual ICollection<Links_LinkDetails> Links_LinkDetails { get; set; } = new List<Links_LinkDetails>();

    public virtual Links_Images? Parent { get; set; }
}
