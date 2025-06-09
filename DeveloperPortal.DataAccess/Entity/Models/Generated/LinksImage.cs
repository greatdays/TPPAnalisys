using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LinksImage
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

    public virtual ICollection<LinksImage> InverseParent { get; set; } = new List<LinksImage>();

    public virtual ICollection<LinksDisplayConfig> LinksDisplayConfigs { get; set; } = new List<LinksDisplayConfig>();

    public virtual ICollection<LinksLinkDetail> LinksLinkDetails { get; set; } = new List<LinksLinkDetail>();

    public virtual LinksImage? Parent { get; set; }
}
