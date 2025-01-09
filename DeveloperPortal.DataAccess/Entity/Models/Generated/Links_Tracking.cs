using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Links_Tracking
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

    public virtual Links_LinkDetails LinkDetails { get; set; } = null!;

    public virtual ICollection<Links_Log> Links_Logs { get; set; } = new List<Links_Log>();
}
