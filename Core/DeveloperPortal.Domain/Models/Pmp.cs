using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Pmp
{
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

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? SpecificPopulationApply { get; set; }

    public bool IsCwlnoPlanAffirmativeMarketing { get; set; }

    public virtual ICollection<AssnPmpagency> AssnPmpagencies { get; set; } = new List<AssnPmpagency>();

    public virtual ICollection<AssnPmplotteryApplnAvailMethod> AssnPmplotteryApplnAvailMethods { get; set; } = new List<AssnPmplotteryApplnAvailMethod>();

    public virtual ICollection<AssnPmplotterySubmitMethod> AssnPmplotterySubmitMethods { get; set; } = new List<AssnPmplotterySubmitMethod>();

    public virtual ICollection<AssnPmpscatteredSite> AssnPmpscatteredSites { get; set; } = new List<AssnPmpscatteredSite>();

    public virtual ICollection<AssnPmpsitesOutreach> AssnPmpsitesOutreaches { get; set; } = new List<AssnPmpsitesOutreach>();

    public virtual LutLegalEntityType? LutLegalEntityType { get; set; }

    public virtual ICollection<PmpaddnlMarketingEffort> PmpaddnlMarketingEfforts { get; set; } = new List<PmpaddnlMarketingEffort>();

    public virtual ICollection<PmpoutreachOrganisation> PmpoutreachOrganisations { get; set; } = new List<PmpoutreachOrganisation>();

    public virtual ICollection<PmppshclientServingOrganization> PmppshclientServingOrganizations { get; set; } = new List<PmppshclientServingOrganization>();
}
