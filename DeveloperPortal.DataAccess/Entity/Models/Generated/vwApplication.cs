using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwApplication
{
    public int ApplicationId { get; set; }

    public string? Name { get; set; }

    public string AppKey { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? JWTAccessCode { get; set; }

    public string? JWTSharedSecrete { get; set; }

    public bool? EnableJWTSecurity { get; set; }

    public bool? IsPublic { get; set; }

    public string? ApplicationURL { get; set; }

    public string? ConnectionString { get; set; }

    public bool IsLocked { get; set; }

    public string? Attributes { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ApplicationDomain { get; set; }
}
