using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRAUTransferWaitList
{
    public int QRAUTransferWaitListID { get; set; }

    public int QuarterlyReportID { get; set; }

    public int? AUTransferWaitListID { get; set; }

    public string? AUTransferWaitListNumber { get; set; }

    public int? CurrentUnitProjectSiteID { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? TransferRequestDate { get; set; }

    public bool? IsPreviousAUWaitList { get; set; }

    public DateTime? AccessibilieWaitListDate { get; set; }

    public int? LutUnitTypeID { get; set; }

    public string? AccessibilityRequest { get; set; }

    public int? LutTotalBedroomID { get; set; }

    public int? LutTotalBathroomID { get; set; }

    public bool IsTransferred { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInProjectSiteID { get; set; }

    public int? MoveInUnitPropSnapShotID { get; set; }

    public int? LutTransferWaitListReasonID { get; set; }

    public DateTime? ReasonDate { get; set; }

    public string? Comment { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AUTransferWaitList? AUTransferWaitList { get; set; }

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
