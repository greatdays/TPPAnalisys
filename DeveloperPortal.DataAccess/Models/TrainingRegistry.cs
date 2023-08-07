using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TrainingRegistry
{
    public int TrainingRegistryId { get; set; }

    public int TrainingSessionId { get; set; }

    public int CaseId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowId { get; set; }

    public int ContactIdentifierId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public int? OrganizationId { get; set; }

    public int? DuplicateOfTrainingRegistryId { get; set; }

    public virtual ICollection<AssnTrainingRegistryProjectSite> AssnTrainingRegistryProjectSites { get; set; } = new List<AssnTrainingRegistryProjectSite>();

    public virtual Case Case { get; set; } = null!;

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual TrainingSession TrainingSession { get; set; } = null!;
}
