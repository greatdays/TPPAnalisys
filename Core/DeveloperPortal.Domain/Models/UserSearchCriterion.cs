using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class UserSearchCriterion
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? Email { get; set; }

    public string SearchCriteriaJson { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
