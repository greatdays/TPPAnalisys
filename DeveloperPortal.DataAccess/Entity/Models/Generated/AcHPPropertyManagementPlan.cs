using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AcHPPropertyManagementPlan
{
    public int PropertyManagementPlanID { get; set; }

    public int ProjectID { get; set; }

    public int? CaseID { get; set; }

    public int? RefAcHPCaseID { get; set; }

    public string? ACHPPreliminaryCertification { get; set; }

    public DateTime? ACHPPreliminaryCertificationDate { get; set; }

    public DateTime? ACHPAffirmativeMarketingDate { get; set; }

    public string? ACHPCertification { get; set; }

    public DateTime? ACHPCertificationDate { get; set; }

    public DateTime? ACHPMarketingDocumentsReceivedDate { get; set; }

    public DateTime? ACHPMarketingDocumentsDueDate { get; set; }

    public string? OMPreliminaryCertification { get; set; }

    public DateTime? OMPreliminaryCertificationDate { get; set; }

    public DateTime? OMAffirmativeMarketingDate { get; set; }

    public string? OMCertification { get; set; }

    public DateTime? OMCertificationDate { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public DateTime? OccupancyDate { get; set; }

    public string? Comment { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid? RowID { get; set; }

    public virtual Case? Case { get; set; }

    public virtual Project Project { get; set; } = null!;
}
