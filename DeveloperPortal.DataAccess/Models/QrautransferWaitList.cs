using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrautransferWaitList
{
    public int QrautransferWaitListId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int? AutransferWaitListId { get; set; }

    public string? AutransferWaitListNumber { get; set; }

    public int? CurrentUnitProjectSiteId { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? TransferRequestDate { get; set; }

    public bool? IsPreviousAuwaitList { get; set; }

    public DateTime? AccessibilieWaitListDate { get; set; }

    public int? LutUnitTypeId { get; set; }

    public string? AccessibilityRequest { get; set; }

    public int? LutTotalBedroomId { get; set; }

    public int? LutTotalBathroomId { get; set; }

    public bool IsTransferred { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInProjectSiteId { get; set; }

    public int? MoveInUnitPropSnapShotId { get; set; }

    public int? LutTransferWaitListReasonId { get; set; }

    public DateTime? ReasonDate { get; set; }

    public string? Comment { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AutransferWaitList? AutransferWaitList { get; set; }

    public virtual ProjectSite? CurrentUnitProjectSite { get; set; }

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual LutTotalBathroom? LutTotalBathroom { get; set; }

    public virtual LutTotalBedroom? LutTotalBedroom { get; set; }

    public virtual LutTransferWaitListReason? LutTransferWaitListReason { get; set; }

    public virtual LutUnitType? LutUnitType { get; set; }

    public virtual ProjectSite? MoveInProjectSite { get; set; }

    public virtual PropSnapshot? MoveInUnitPropSnapShot { get; set; }

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
