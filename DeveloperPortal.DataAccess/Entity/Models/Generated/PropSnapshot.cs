using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PropSnapshot
{
    public int PropSnapshotId { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int? Apnid { get; set; }

    public int? ProjectId { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? SiteAddressId { get; set; }

    public int? StructureId { get; set; }

    public int? LevelId { get; set; }

    public int? UnitId { get; set; }

    public int? LocationId { get; set; }

    public string? IdentifierJson { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Apn? Apn { get; set; }

    public virtual ICollection<AssnBackgroundCheck> AssnBackgroundChecks { get; set; } = new List<AssnBackgroundCheck>();

    public virtual ICollection<AssnPmpscatteredSiteSnap> AssnPmpscatteredSiteSnaps { get; set; } = new List<AssnPmpscatteredSiteSnap>();

    public virtual ICollection<AssnPmpscatteredSite> AssnPmpscatteredSites { get; set; } = new List<AssnPmpscatteredSite>();

    public virtual ICollection<AssnPmpsitesOutreachSnap> AssnPmpsitesOutreachSnaps { get; set; } = new List<AssnPmpsitesOutreachSnap>();

    public virtual ICollection<AssnPmpsitesOutreach> AssnPmpsitesOutreaches { get; set; } = new List<AssnPmpsitesOutreach>();

    public virtual ICollection<AssnPropertyDistrict> AssnPropertyDistricts { get; set; } = new List<AssnPropertyDistrict>();

    public virtual ICollection<AssnUserPropertyFavouriteCase> AssnUserPropertyFavouriteCases { get; set; } = new List<AssnUserPropertyFavouriteCase>();

    public virtual ICollection<AutransferWaitList> AutransferWaitListCurrentUnitPropSnapShots { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AutransferWaitList> AutransferWaitListMoveInUnitPropSnapShots { get; set; } = new List<AutransferWaitList>();

    public virtual ICollection<AuwaitList> AuwaitListMoveInUnitPropSnapShots { get; set; } = new List<AuwaitList>();

    public virtual ICollection<AuwaitList> AuwaitListProjSitePropSnapShots { get; set; } = new List<AuwaitList>();

    public virtual ICollection<CorrectionNote> CorrectionNotes { get; set; } = new List<CorrectionNote>();

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<FairHousing> FairHousings { get; set; } = new List<FairHousing>();

    public virtual ICollection<FhpropertyAssociatedAccount> FhpropertyAssociatedAccounts { get; set; } = new List<FhpropertyAssociatedAccount>();

    public virtual ICollection<GrievanceLog> GrievanceLogProjSitePropSnapShots { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<GrievanceLog> GrievanceLogUnitPropSnapShots { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();

    public virtual Level? Level { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<NewStaffContactInfo> NewStaffContactInfos { get; set; } = new List<NewStaffContactInfo>();

    public virtual ICollection<Pmpsnap> Pmpsnaps { get; set; } = new List<Pmpsnap>();

    public virtual ICollection<PmpunitAttributeSnap> PmpunitAttributeSnaps { get; set; } = new List<PmpunitAttributeSnap>();

    public virtual ICollection<PmpunitSnap> PmpunitSnaps { get; set; } = new List<PmpunitSnap>();

    public virtual Project? Project { get; set; }

    public virtual ICollection<ProjectAttribute> ProjectAttributes { get; set; } = new List<ProjectAttribute>();

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual ICollection<ProjectSiteAttributeSnap> ProjectSiteAttributeSnaps { get; set; } = new List<ProjectSiteAttributeSnap>();

    public virtual ICollection<ProjectSiteAttribute> ProjectSiteAttributes { get; set; } = new List<ProjectSiteAttribute>();

    public virtual ICollection<ProjectSiteFutureWaitList> ProjectSiteFutureWaitLists { get; set; } = new List<ProjectSiteFutureWaitList>();

    public virtual ICollection<ProjectSiteNoChangeReport> ProjectSiteNoChangeReports { get; set; } = new List<ProjectSiteNoChangeReport>();

    public virtual ICollection<ProjectSiteUpcomingUnitVacancy> ProjectSiteUpcomingUnitVacancies { get; set; } = new List<ProjectSiteUpcomingUnitVacancy>();

    public virtual ICollection<PropAttribute> PropAttributes { get; set; } = new List<PropAttribute>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitListCurrentUnitPropSnapShots { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrautransferWaitList> QrautransferWaitListMoveInUnitPropSnapShots { get; set; } = new List<QrautransferWaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitListCurrentUnitPropSnapShots { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QrauwaitList> QrauwaitListMoveInUnitPropSnapShots { get; set; } = new List<QrauwaitList>();

    public virtual ICollection<QreffectiveCommunication> QreffectiveCommunications { get; set; } = new List<QreffectiveCommunication>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogProjSitePropSnapShots { get; set; } = new List<QrgrievanceLog>();

    public virtual ICollection<QrgrievanceLog> QrgrievanceLogUnitPropSnapShots { get; set; } = new List<QrgrievanceLog>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnitCurrentProjSitePropSnapShots { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnitCurrentUnitPropSnapShots { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnitPreviousProjSitePropSnapShots { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnitPreviousUnitPropSnapShots { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QroccupancyUnit> QroccupancyUnitUnitPropSnapShots { get; set; } = new List<QroccupancyUnit>();

    public virtual ICollection<QrreasonableAccommodation> QrreasonableAccommodations { get; set; } = new List<QrreasonableAccommodation>();

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancyCurrentUnitPropSnapShots { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancyProjSitePropSnapShots { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual ICollection<QrupcomingUnitVacancy> QrupcomingUnitVacancyUnitPropSnapShots { get; set; } = new List<QrupcomingUnitVacancy>();

    public virtual ICollection<QrutilizationSurvey> QrutilizationSurveys { get; set; } = new List<QrutilizationSurvey>();

    public virtual ICollection<QuarterlyReport> QuarterlyReports { get; set; } = new List<QuarterlyReport>();

    public virtual ICollection<ReasonableAccommodation> ReasonableAccommodations { get; set; } = new List<ReasonableAccommodation>();

    public virtual SiteAddress? SiteAddress { get; set; }

    public virtual Structure? Structure { get; set; }

    public virtual ICollection<StructureAttribute> StructureAttributes { get; set; } = new List<StructureAttribute>();

    public virtual Unit? Unit { get; set; }

    public virtual ICollection<UnitAttribute> UnitAttributeCurrentProjSitePropSnapShots { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributeCurrentUnitPropSnapShots { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributePreviousProjSitePropSnapShots { get; set; } = new List<UnitAttribute>();

    public virtual ICollection<UnitAttribute> UnitAttributePreviousUnitPropSnapShots { get; set; } = new List<UnitAttribute>();

    public virtual UnitAttribute? UnitAttributePropSnapshot { get; set; }

    public virtual ICollection<UpcomingUnitVacancy> UpcomingUnitVacancyCurrentUnitPropSnapShots { get; set; } = new List<UpcomingUnitVacancy>();

    public virtual ICollection<UpcomingUnitVacancy> UpcomingUnitVacancyProjSitePropSnapShots { get; set; } = new List<UpcomingUnitVacancy>();

    public virtual ICollection<UpcomingUnitVacancy> UpcomingUnitVacancyUnitPropSnapShots { get; set; } = new List<UpcomingUnitVacancy>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
}
