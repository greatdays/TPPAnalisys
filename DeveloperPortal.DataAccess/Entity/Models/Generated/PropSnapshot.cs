using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PropSnapshot
{
    public int PropSnapshotID { get; set; }

    public string IdentifierType { get; set; } = null!;

    public int? APNID { get; set; }

    public int? ProjectID { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? SiteAddressID { get; set; }

    public int? StructureID { get; set; }

    public int? LevelID { get; set; }

    public int? UnitID { get; set; }

    public int? LocationID { get; set; }

    public string? IdentifierJSON { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual APN? APN { get; set; }

    public virtual ICollection<AUTransferWaitList> AUTransferWaitListCurrentUnitPropSnapShots { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUTransferWaitList> AUTransferWaitListMoveInUnitPropSnapShots { get; set; } = new List<AUTransferWaitList>();

    public virtual ICollection<AUWaitList> AUWaitListMoveInUnitPropSnapShots { get; set; } = new List<AUWaitList>();

    public virtual ICollection<AUWaitList> AUWaitListProjSitePropSnapShots { get; set; } = new List<AUWaitList>();

    public virtual ICollection<AssnBackgroundCheck> AssnBackgroundChecks { get; set; } = new List<AssnBackgroundCheck>();

    public virtual ICollection<AssnPMPScatteredSiteSnap> AssnPMPScatteredSiteSnaps { get; set; } = new List<AssnPMPScatteredSiteSnap>();

    public virtual ICollection<AssnPMPScatteredSite> AssnPMPScatteredSites { get; set; } = new List<AssnPMPScatteredSite>();

    public virtual ICollection<AssnPMPSitesOutreachSnap> AssnPMPSitesOutreachSnaps { get; set; } = new List<AssnPMPSitesOutreachSnap>();

    public virtual ICollection<AssnPMPSitesOutreach> AssnPMPSitesOutreaches { get; set; } = new List<AssnPMPSitesOutreach>();

    public virtual ICollection<AssnPropertyDistrict> AssnPropertyDistricts { get; set; } = new List<AssnPropertyDistrict>();

    public virtual ICollection<AssnUserPropertyFavouriteCase> AssnUserPropertyFavouriteCases { get; set; } = new List<AssnUserPropertyFavouriteCase>();

    public virtual ICollection<CorrectionNote> CorrectionNotes { get; set; } = new List<CorrectionNote>();

    public virtual ICollection<EffectiveCommunication> EffectiveCommunications { get; set; } = new List<EffectiveCommunication>();

    public virtual ICollection<FairHousing> FairHousings { get; set; } = new List<FairHousing>();

    public virtual ICollection<GrievanceLog> GrievanceLogProjSitePropSnapShots { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<GrievanceLog> GrievanceLogUnitPropSnapShots { get; set; } = new List<GrievanceLog>();

    public virtual ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();

    public virtual Level? Level { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<PMPSnap> PMPSnaps { get; set; } = new List<PMPSnap>();

    public virtual ICollection<PMPUnitAttributeSnap> PMPUnitAttributeSnaps { get; set; } = new List<PMPUnitAttributeSnap>();

    public virtual ICollection<PMPUnitSnap> PMPUnitSnaps { get; set; } = new List<PMPUnitSnap>();

    public virtual Project? Project { get; set; }

    public virtual ICollection<ProjectAttribute> ProjectAttributes { get; set; } = new List<ProjectAttribute>();

    public virtual ProjectSite? ProjectSite { get; set; }

    public virtual ICollection<ProjectSiteAttributeSnap> ProjectSiteAttributeSnaps { get; set; } = new List<ProjectSiteAttributeSnap>();

    public virtual ICollection<ProjectSiteAttribute> ProjectSiteAttributes { get; set; } = new List<ProjectSiteAttribute>();

    public virtual ICollection<ProjectSiteFutureWaitList> ProjectSiteFutureWaitLists { get; set; } = new List<ProjectSiteFutureWaitList>();

    public virtual ICollection<ProjectSiteNoChangeReport> ProjectSiteNoChangeReports { get; set; } = new List<ProjectSiteNoChangeReport>();

    public virtual ICollection<ProjectSiteUpcomingUnitVacancy> ProjectSiteUpcomingUnitVacancies { get; set; } = new List<ProjectSiteUpcomingUnitVacancy>();

    public virtual ICollection<PropAttribute> PropAttributes { get; set; } = new List<PropAttribute>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitListCurrentUnitPropSnapShots { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUTransferWaitList> QRAUTransferWaitListMoveInUnitPropSnapShots { get; set; } = new List<QRAUTransferWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitListCurrentUnitPropSnapShots { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QRAUWaitList> QRAUWaitListMoveInUnitPropSnapShots { get; set; } = new List<QRAUWaitList>();

    public virtual ICollection<QREffectiveCommunication> QREffectiveCommunications { get; set; } = new List<QREffectiveCommunication>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogProjSitePropSnapShots { get; set; } = new List<QRGrievanceLog>();

    public virtual ICollection<QRGrievanceLog> QRGrievanceLogUnitPropSnapShots { get; set; } = new List<QRGrievanceLog>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnitCurrentProjSitePropSnapShots { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnitCurrentUnitPropSnapShots { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnitPreviousProjSitePropSnapShots { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnitPreviousUnitPropSnapShots { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QROccupancyUnit> QROccupancyUnitUnitPropSnapShots { get; set; } = new List<QROccupancyUnit>();

    public virtual ICollection<QRReasonableAccommodation> QRReasonableAccommodations { get; set; } = new List<QRReasonableAccommodation>();

    public virtual ICollection<QRUpcomingUnitVacancy> QRUpcomingUnitVacancyCurrentUnitPropSnapShots { get; set; } = new List<QRUpcomingUnitVacancy>();

    public virtual ICollection<QRUpcomingUnitVacancy> QRUpcomingUnitVacancyProjSitePropSnapShots { get; set; } = new List<QRUpcomingUnitVacancy>();

    public virtual ICollection<QRUpcomingUnitVacancy> QRUpcomingUnitVacancyUnitPropSnapShots { get; set; } = new List<QRUpcomingUnitVacancy>();

    public virtual ICollection<QRUtilizationSurvey> QRUtilizationSurveys { get; set; } = new List<QRUtilizationSurvey>();

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
