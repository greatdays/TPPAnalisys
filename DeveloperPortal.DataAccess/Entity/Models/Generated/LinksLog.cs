using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LinksLog
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This field is reference to LinkTracking table LinkTrackingID
    /// </summary>
    public int LinkTrackingId { get; set; }

    /// <summary>
    /// This field is used to store date and time when user click the link.
    /// </summary>
    public DateTime ClickDate { get; set; }

    /// <summary>
    /// This field is used to store userID, who was click the link. 
    /// </summary>
    public int? UserId { get; set; }

    public virtual LinksTracking LinkTracking { get; set; } = null!;
}
