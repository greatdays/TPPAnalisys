using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class TrainingRegistry
{
    public int TrainingRegistryID { get; set; }

    public int TrainingSessionID { get; set; }

    public int CaseID { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public Guid RowID { get; set; }

    public int ContactIdentifierID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public int? OrganizationID { get; set; }

    public int? DuplicateOfTrainingRegistryID { get; set; }

    public virtual ICollection<AssnTrainingRegistryProjectSite> AssnTrainingRegistryProjectSites { get; set; } = new List<AssnTrainingRegistryProjectSite>();

    public virtual Case Case { get; set; } = null!;

    public virtual ContactIdentifier ContactIdentifier { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual TrainingSession TrainingSession { get; set; } = null!;
}
