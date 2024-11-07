using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class QRAUWaitList
{
    public int QRAUWaitListID { get; set; }

    public int QuarterlyReportID { get; set; }

    public int AUWaitListID { get; set; }

    public string? AUWaitListNumber { get; set; }

    public int? HRMApplicationID { get; set; }

    public int? CurrentUnitPropSnapShotID { get; set; }

    public int? LutApplicationTypeID { get; set; }

    public DateTime? ApplicationDateTime { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? AUWaitListPosition { get; set; }

    public int? LotteryPosition { get; set; }

    public string? WaitListPosition { get; set; }

    public int? LutUnitTypeID { get; set; }

    public int? LutTotalBedroomID { get; set; }

    public int? LutTotalBathroomID { get; set; }

    public string? AccessibilityRequest { get; set; }

    public bool? IsApplicantMovedIn { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInUnitProjectSiteID { get; set; }

    public int? MoveInUnitPropSnapShotID { get; set; }

    public string? ApplicantMovedUnit { get; set; }

    public DateTime? TenantAUTransferDate { get; set; }

    public bool? IsTenantMadeRA { get; set; }

    public DateTime? TenantMadeRADate { get; set; }

    public string? NatureOfRARequests { get; set; }

    public string? ApplicantNotMovedReason { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AUWaitList AUWaitList { get; set; } = null!;

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual LutApplicationType? LutApplicationType { get; set; }

    public virtual LutTotalBathroom? LutTotalBathroom { get; set; }

    public virtual LutTotalBedroom? LutTotalBedroom { get; set; }

    public virtual LutUnitType? LutUnitType { get; set; }

    public virtual ProjectSite? MoveInUnitProjectSite { get; set; }

    public virtual PropSnapshot? MoveInUnitPropSnapShot { get; set; }

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
