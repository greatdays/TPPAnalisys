using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAffordableApplicationCloseDateNotification
{
    public int ProjectSiteSnapID { get; set; }

    public int ProjectSiteID { get; set; }

    public int ShowNotification { get; set; }

    public string Notification { get; set; } = null!;
}
