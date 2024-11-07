using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Table holds Inspection Notification.
/// </summary>
public partial class InspectionNotification
{
    public int InspectionNotificationID { get; set; }

    public int InspectionID { get; set; }

    public string? InspectorUserName { get; set; }

    public string? AssignedBy { get; set; }

    public bool IsDecline { get; set; }

    public bool IsNotificationCheck { get; set; }

    /// <summary>
    /// Created by which user
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Created on which datetime
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// Modified by which user
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified on which datetime
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    public virtual Inspection Inspection { get; set; } = null!;

    public virtual InspectionScheduled InspectionNavigation { get; set; } = null!;
}
