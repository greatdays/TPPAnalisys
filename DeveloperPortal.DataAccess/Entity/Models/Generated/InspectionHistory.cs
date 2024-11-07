using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Table holds Inspection Request History.
/// </summary>
public partial class InspectionHistory
{
    public int InspectionHistoryID { get; set; }

    public int InspectionID { get; set; }

    public int? LutCancelReasonID { get; set; }

    public int? LutScheduleReasonID { get; set; }

    /// <summary>
    /// Primary key of the table
    /// </summary>
    public int CaseLogId { get; set; }

    public DateTime? ScheduledStartOn { get; set; }

    public DateTime? ScheduledEndOn { get; set; }

    public DateTime? InspectedStartOn { get; set; }

    public DateTime? InspectedEndOn { get; set; }

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
