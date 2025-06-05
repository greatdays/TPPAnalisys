using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class TrainingSession13
{
    public int TrainingRegistryId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int TrainingSessionId { get; set; }

    public string? Comment { get; set; }
}
