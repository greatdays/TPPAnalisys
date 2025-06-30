using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AcHppropertyManagementPlan
{
    public int PropertyManagementPlanId { get; set; }

    public int ProjectId { get; set; }

    public int? CaseId { get; set; }

    public int? RefAcHpcaseId { get; set; }

    public string? AchppreliminaryCertification { get; set; }

    public DateTime? AchppreliminaryCertificationDate { get; set; }

    public DateTime? AchpaffirmativeMarketingDate { get; set; }

    public string? Achpcertification { get; set; }

    public DateTime? AchpcertificationDate { get; set; }

    public DateTime? AchpmarketingDocumentsReceivedDate { get; set; }

    public DateTime? AchpmarketingDocumentsDueDate { get; set; }

    public string? OmpreliminaryCertification { get; set; }

    public DateTime? OmpreliminaryCertificationDate { get; set; }

    public DateTime? OmaffirmativeMarketingDate { get; set; }

    public string? Omcertification { get; set; }

    public DateTime? OmcertificationDate { get; set; }

    public DateTime? ApplicationStartDate { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public DateTime? OccupancyDate { get; set; }

    public string? Comment { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsLocked { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid? RowId { get; set; }

    public virtual Case? Case { get; set; }

    public virtual Project Project { get; set; } = null!;
}
