using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class QrauwaitList
{
    public int QrauwaitListId { get; set; }

    public int QuarterlyReportId { get; set; }

    public int AuwaitListId { get; set; }

    public string? AuwaitListNumber { get; set; }

    public int? HrmapplicationId { get; set; }

    public int? CurrentUnitPropSnapShotId { get; set; }

    public int? LutApplicationTypeId { get; set; }

    public DateTime? ApplicationDateTime { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? AuwaitListPosition { get; set; }

    public int? LotteryPosition { get; set; }

    public string? WaitListPosition { get; set; }

    public int? LutUnitTypeId { get; set; }

    public int? LutTotalBedroomId { get; set; }

    public int? LutTotalBathroomId { get; set; }

    public string? AccessibilityRequest { get; set; }

    public bool? IsApplicantMovedIn { get; set; }

    public DateTime? MovedInDate { get; set; }

    public int? MoveInUnitProjectSiteId { get; set; }

    public int? MoveInUnitPropSnapShotId { get; set; }

    public string? ApplicantMovedUnit { get; set; }

    public DateTime? TenantAutransferDate { get; set; }

    public bool? IsTenantMadeRa { get; set; }

    public DateTime? TenantMadeRadate { get; set; }

    public string? NatureOfRarequests { get; set; }

    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AuwaitList AuwaitList { get; set; } = null!;

    public virtual PropSnapshot? CurrentUnitPropSnapShot { get; set; }

    public virtual LutApplicationType? LutApplicationType { get; set; }

    public virtual LutTotalBathroom? LutTotalBathroom { get; set; }

    public virtual LutTotalBedroom? LutTotalBedroom { get; set; }

    public virtual LutUnitType? LutUnitType { get; set; }

    public virtual ProjectSite? MoveInUnitProjectSite { get; set; }

    public virtual PropSnapshot? MoveInUnitPropSnapShot { get; set; }

    public virtual QuarterlyReport QuarterlyReport { get; set; } = null!;
}
