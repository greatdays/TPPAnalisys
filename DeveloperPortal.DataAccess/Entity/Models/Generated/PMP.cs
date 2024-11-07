using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMP
{
    public int PMPID { get; set; }

    public long ServiceRequestID { get; set; }

    public int PropSnapshotID { get; set; }

    public int? LutConstructionTypeID { get; set; }

    public int? LutCESTypeID { get; set; }

    public DateTime? PreliminaryCertificateDate { get; set; }

    public DateTime? FinalCertificateDate { get; set; }

    public string? AdmObjSelectionCriteria { get; set; }

    public string? AdmTenantSelectionProcess { get; set; }

    public bool IsComplyAdmRequirement { get; set; }

    public bool IsComplyLAHSACES { get; set; }

    public string? VacancyPolicyDesc { get; set; }

    public bool IsComplyVacancyPolicy { get; set; }

    public string? WaitListAddInfo { get; set; }

    public string? WaitListDescForHOPWA { get; set; }

    public bool IsComplyWaitList { get; set; }

    public string? OwnerName { get; set; }

    public bool? IsOwnerLegalEntity { get; set; }

    public int? LutLegalEntityTypeId { get; set; }

    public string? OtherLegalEntityType { get; set; }

    public string? LegalEntityName { get; set; }

    public string? LegalEntityContactName { get; set; }

    public string? EntityContactPhone { get; set; }

    public string? EntityContactPhoneExt { get; set; }

    public string? EntityContactEmail { get; set; }

    public string? AuthSignatoryName { get; set; }

    public string? SignatoryPersonTitle { get; set; }

    public DateTime? DateOfAckCertificate { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsFinalSigned { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? SpecificPopulationApply { get; set; }

    public bool IsCWLNoPlanAffirmativeMarketing { get; set; }

    public bool? IsTenantRightsToReturn { get; set; }

    public int? NoUnitsOccupiedReturningTenant { get; set; }

    public int? ReturningTenantMobilityUnits { get; set; }

    public int? ReturningTenantHearningUnits { get; set; }

    public string? ReturningTenantOccupyAUs { get; set; }

    public bool? IsProjectUseUHA { get; set; }

    public virtual ICollection<AssnPMPAgency> AssnPMPAgencies { get; set; } = new List<AssnPMPAgency>();

    public virtual ICollection<AssnPMPLotteryApplnAvailMethod> AssnPMPLotteryApplnAvailMethods { get; set; } = new List<AssnPMPLotteryApplnAvailMethod>();

    public virtual ICollection<AssnPMPLotterySubmitMethod> AssnPMPLotterySubmitMethods { get; set; } = new List<AssnPMPLotterySubmitMethod>();

    public virtual ICollection<AssnPMPScatteredSite> AssnPMPScatteredSites { get; set; } = new List<AssnPMPScatteredSite>();

    public virtual ICollection<AssnPMPSitesOutreach> AssnPMPSitesOutreaches { get; set; } = new List<AssnPMPSitesOutreach>();

    public virtual LutLegalEntityType? LutLegalEntityType { get; set; }

    public virtual ICollection<PMPAddnlMarketingEffort> PMPAddnlMarketingEfforts { get; set; } = new List<PMPAddnlMarketingEffort>();

    public virtual ICollection<PMPOutreachOrganisation> PMPOutreachOrganisations { get; set; } = new List<PMPOutreachOrganisation>();

    public virtual ICollection<PMPPSHClientServingOrganization> PMPPSHClientServingOrganizations { get; set; } = new List<PMPPSHClientServingOrganization>();

    public virtual ICollection<PMPSnap> PMPSnaps { get; set; } = new List<PMPSnap>();

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
