using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Links_DisplayConfig
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// This filed is used to store how do you display active links.(Horizontal or Verticle)
    /// </summary>
    public string DisplayOption { get; set; } = null!;

    /// <summary>
    /// This field is used to store how many links you want to display.
    /// </summary>
    public int? NoOfLinkToDisplay { get; set; }

    /// <summary>
    /// This field is used to store display icon before link.
    /// </summary>
    public bool? IsDisplayIcon { get; set; }

    /// <summary>
    /// This field is used to store if true then icon type active. Use same or different icon for each link.
    /// </summary>
    public bool? IsDisplaySameIcon { get; set; }

    /// <summary>
    /// This field is reference to Files table ImageID.
    /// </summary>
    public int? ImageId { get; set; }

    /// <summary>
    /// This field is used to store if true then favorite links active. Links which is most clickable in this website.
    /// </summary>
    public bool? IsDisplayFavouriteLinks { get; set; }

    public virtual ICollection<ControlViewMaster> ControlViewMasters { get; set; } = new List<ControlViewMaster>();

    public virtual Links_Images? Links_Images { get; set; }

    public virtual ICollection<Links_LinkDetails> Links_LinkDetails { get; set; } = new List<Links_LinkDetails>();
}
