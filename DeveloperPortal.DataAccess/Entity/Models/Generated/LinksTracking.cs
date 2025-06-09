using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LinksTracking
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This field is reference to Links table LinkID.
    /// </summary>
    public int LinkDetailsId { get; set; }

    /// <summary>
    /// This field is used to store how many hits on this link.
    /// </summary>
    public int Clicks { get; set; }

    /// <summary>
    /// This field is used to store when this link hit at last time.
    /// </summary>
    public DateTime? LastClick { get; set; }

    public virtual LinksLinkDetail LinkDetails { get; set; } = null!;

    public virtual ICollection<LinksLog> LinksLogs { get; set; } = new List<LinksLog>();
}
