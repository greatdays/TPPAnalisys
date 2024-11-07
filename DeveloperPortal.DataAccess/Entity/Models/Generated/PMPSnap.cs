using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class PMPSnap
{
    public int PMPSnapID { get; set; }

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

    public string? SpecificPopulationApply { get; set; }

    public bool IsCWLNoPlanAffirmativeMarketing { get; set; }

    public bool? IsTenantRightsToReturn { get; set; }

    public int? NoUnitsOccupiedReturningTenant { get; set; }

    public int? ReturningTenantMobilityUnits { get; set; }

    public int? ReturningTenantHearningUnits { get; set; }

    public string? ReturningTenantOccupyAUs { get; set; }

    public bool? IsProjectUseUHA { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<AssnPMPAgencySnap> AssnPMPAgencySnaps { get; set; } = new List<AssnPMPAgencySnap>();

    public virtual ICollection<AssnPMPLotteryApplnAvailMethodSnap> AssnPMPLotteryApplnAvailMethodSnaps { get; set; } = new List<AssnPMPLotteryApplnAvailMethodSnap>();

    public virtual ICollection<AssnPMPLotterySubmitMethodSnap> AssnPMPLotterySubmitMethodSnaps { get; set; } = new List<AssnPMPLotterySubmitMethodSnap>();

    public virtual ICollection<AssnPMPOutreachTargetAudienceSnap> AssnPMPOutreachTargetAudienceSnaps { get; set; } = new List<AssnPMPOutreachTargetAudienceSnap>();

    public virtual ICollection<AssnPMPProjSiteAccessibleUnitFeatureSnap> AssnPMPProjSiteAccessibleUnitFeatureSnaps { get; set; } = new List<AssnPMPProjSiteAccessibleUnitFeatureSnap>();

    public virtual ICollection<AssnPMPProjTypeSiteAttrSnap> AssnPMPProjTypeSiteAttrSnaps { get; set; } = new List<AssnPMPProjTypeSiteAttrSnap>();

    public virtual ICollection<AssnPMPScatteredSiteSnap> AssnPMPScatteredSiteSnaps { get; set; } = new List<AssnPMPScatteredSiteSnap>();

    public virtual ICollection<AssnPMPSitesOutreachSnap> AssnPMPSitesOutreachSnaps { get; set; } = new List<AssnPMPSitesOutreachSnap>();

    public virtual ICollection<AssnPMPUnitFeatureSnap> AssnPMPUnitFeatureSnaps { get; set; } = new List<AssnPMPUnitFeatureSnap>();

    public virtual LutCESType? LutCESType { get; set; }

    public virtual LutConstructionType? LutConstructionType { get; set; }

    public virtual LutLegalEntityType? LutLegalEntityType { get; set; }

    public virtual PMP PMP { get; set; } = null!;

    public virtual ICollection<PMPAddnlMarketingEffortSnap> PMPAddnlMarketingEffortSnaps { get; set; } = new List<PMPAddnlMarketingEffortSnap>();

    public virtual ICollection<PMPAgencySnap> PMPAgencySnaps { get; set; } = new List<PMPAgencySnap>();

    public virtual ICollection<PMPOutreachAndAffimativeMarketingSnap> PMPOutreachAndAffimativeMarketingSnaps { get; set; } = new List<PMPOutreachAndAffimativeMarketingSnap>();

    public virtual ICollection<PMPOutreachOrganisationSnap> PMPOutreachOrganisationSnaps { get; set; } = new List<PMPOutreachOrganisationSnap>();

    public virtual ICollection<PMPPSHClientServingOrganizationSnap> PMPPSHClientServingOrganizationSnaps { get; set; } = new List<PMPPSHClientServingOrganizationSnap>();

    public virtual ICollection<PMPProjectSiteSnap> PMPProjectSiteSnaps { get; set; } = new List<PMPProjectSiteSnap>();

    public virtual ICollection<PMPSiteAddressSnap> PMPSiteAddressSnaps { get; set; } = new List<PMPSiteAddressSnap>();

    public virtual ICollection<PMPUnitInfoSummarySnap> PMPUnitInfoSummarySnaps { get; set; } = new List<PMPUnitInfoSummarySnap>();

    public virtual ICollection<PMPUnitSnap> PMPUnitSnaps { get; set; } = new List<PMPUnitSnap>();

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;

    public virtual ICollection<ReviewPMPLogSnap> ReviewPMPLogSnaps { get; set; } = new List<ReviewPMPLogSnap>();

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
