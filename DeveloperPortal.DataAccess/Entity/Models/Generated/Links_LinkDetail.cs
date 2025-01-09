using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Links_LinkDetails
{
    public Links_LinkDetails()
    {
        this.Links_Trackings = new HashSet<Links_Tracking>();
    }

    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    public int DisplayConfigId { get; set; }

    /// <summary>
    /// This field is reference to Files table ImageID.
    /// </summary>
    public int? ImageId { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// This filed is used to store Link type (Url or Page).
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// This field is used to store Link address(Url).
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// This field is used to store passed paramater string to Link Address.
    /// </summary>
    public string? Parameter { get; set; }

    /// <summary>
    /// This field is used to store number representing the position in the list for this link.
    /// </summary>
    public int? ViewOrder { get; set; }

    /// <summary>
    /// This field is used for active or inactive the link.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// This field is used to store if true then always open the link in new window.
    /// </summary>
    public bool? IsOpenNewWindow { get; set; }

    /// <summary>
    /// This field is used to store if true then keep logactivity of this link.
    /// </summary>
    public bool? IsLogEnabled { get; set; }

    /// <summary>
    /// This field is used to store if true then track how many times hit the link.
    /// </summary>
    public bool? IsTrackingEnabled { get; set; }

    public virtual Links_DisplayConfig DisplayConfig { get; set; } = null!;

    public virtual Links_Images? Links_Images { get; set; }

    public virtual ICollection<Links_Tracking> Links_Trackings { get; set; } = new List<Links_Tracking>();
}
