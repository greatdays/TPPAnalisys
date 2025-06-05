using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class Pmpsnap
{
    public int PmpsnapId { get; set; }

    public int Pmpid { get; set; }

    public long ServiceRequestId { get; set; }

    public int PropSnapshotId { get; set; }

    public int? LutConstructionTypeId { get; set; }

    public int? LutCestypeId { get; set; }

    public DateTime? PreliminaryCertificateDate { get; set; }

    public DateTime? FinalCertificateDate { get; set; }

    public string? AdmObjSelectionCriteria { get; set; }

    public string? AdmTenantSelectionProcess { get; set; }

    public bool IsComplyAdmRequirement { get; set; }

    public bool IsComplyLahsaces { get; set; }

    public string? VacancyPolicyDesc { get; set; }

    public bool IsComplyVacancyPolicy { get; set; }

    public string? WaitListAddInfo { get; set; }

    public string? WaitListDescForHopwa { get; set; }

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

    public bool IsCwlnoPlanAffirmativeMarketing { get; set; }

    public bool? IsTenantRightsToReturn { get; set; }

    public int? NoUnitsOccupiedReturningTenant { get; set; }

    public int? ReturningTenantMobilityUnits { get; set; }

    public int? ReturningTenantHearningUnits { get; set; }

    public string? ReturningTenantOccupyAus { get; set; }

    public bool? IsProjectUseUha { get; set; }

    public bool IsLocked { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<AssnPmpagencySnap> AssnPmpagencySnaps { get; set; } = new List<AssnPmpagencySnap>();

    public virtual ICollection<AssnPmplotteryApplnAvailMethodSnap> AssnPmplotteryApplnAvailMethodSnaps { get; set; } = new List<AssnPmplotteryApplnAvailMethodSnap>();

    public virtual ICollection<AssnPmplotterySubmitMethodSnap> AssnPmplotterySubmitMethodSnaps { get; set; } = new List<AssnPmplotterySubmitMethodSnap>();

    public virtual ICollection<AssnPmpoutreachTargetAudienceSnap> AssnPmpoutreachTargetAudienceSnaps { get; set; } = new List<AssnPmpoutreachTargetAudienceSnap>();

    public virtual ICollection<AssnPmpprojSiteAccessibleUnitFeatureSnap> AssnPmpprojSiteAccessibleUnitFeatureSnaps { get; set; } = new List<AssnPmpprojSiteAccessibleUnitFeatureSnap>();

    public virtual ICollection<AssnPmpprojTypeSiteAttrSnap> AssnPmpprojTypeSiteAttrSnaps { get; set; } = new List<AssnPmpprojTypeSiteAttrSnap>();

    public virtual ICollection<AssnPmpscatteredSiteSnap> AssnPmpscatteredSiteSnaps { get; set; } = new List<AssnPmpscatteredSiteSnap>();

    public virtual ICollection<AssnPmpsitesOutreachSnap> AssnPmpsitesOutreachSnaps { get; set; } = new List<AssnPmpsitesOutreachSnap>();

    public virtual ICollection<AssnPmpunitFeatureSnap> AssnPmpunitFeatureSnaps { get; set; } = new List<AssnPmpunitFeatureSnap>();

    public virtual LutCestype? LutCestype { get; set; }

    public virtual LutConstructionType? LutConstructionType { get; set; }

    public virtual LutLegalEntityType? LutLegalEntityType { get; set; }

    public virtual Pmp Pmp { get; set; } = null!;

    public virtual ICollection<PmpaddnlMarketingEffortSnap> PmpaddnlMarketingEffortSnaps { get; set; } = new List<PmpaddnlMarketingEffortSnap>();

    public virtual ICollection<PmpagencySnap> PmpagencySnaps { get; set; } = new List<PmpagencySnap>();

    public virtual ICollection<PmpoutreachAndAffimativeMarketingSnap> PmpoutreachAndAffimativeMarketingSnaps { get; set; } = new List<PmpoutreachAndAffimativeMarketingSnap>();

    public virtual ICollection<PmpoutreachOrganisationSnap> PmpoutreachOrganisationSnaps { get; set; } = new List<PmpoutreachOrganisationSnap>();

    public virtual ICollection<PmpprojectSiteSnap> PmpprojectSiteSnaps { get; set; } = new List<PmpprojectSiteSnap>();

    public virtual ICollection<PmppshclientServingOrganizationSnap> PmppshclientServingOrganizationSnaps { get; set; } = new List<PmppshclientServingOrganizationSnap>();

    public virtual ICollection<PmpsiteAddressSnap> PmpsiteAddressSnaps { get; set; } = new List<PmpsiteAddressSnap>();

    public virtual ICollection<PmpunitInfoSummarySnap> PmpunitInfoSummarySnaps { get; set; } = new List<PmpunitInfoSummarySnap>();

    public virtual ICollection<PmpunitSnap> PmpunitSnaps { get; set; } = new List<PmpunitSnap>();

    public virtual PropSnapshot PropSnapshot { get; set; } = null!;

    public virtual ICollection<ReviewPmplogSnap> ReviewPmplogSnaps { get; set; } = new List<ReviewPmplogSnap>();

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
