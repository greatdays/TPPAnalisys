using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwAffordableApplicationCloseDateNotification
{
    public int ProjectSiteSnapId { get; set; }

    public int ProjectSiteId { get; set; }

    public int ShowNotification { get; set; }

    public string Notification { get; set; } = null!;
}
