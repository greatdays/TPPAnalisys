using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class VwPropertyContact
{
    public int ProjectId { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string ContactType { get; set; } = null!;
}
