using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutEapfeature
{
    public int LutEapfeatureId { get; set; }

    public string Eapfeature { get; set; } = null!;

    public string? ProjectType { get; set; }

    public string? TableType { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }
}
