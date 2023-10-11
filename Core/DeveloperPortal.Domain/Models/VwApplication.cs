using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwApplication
{
    public int ApplicationId { get; set; }

    public string? Name { get; set; }

    public string AppKey { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? JwtaccessCode { get; set; }

    public string? JwtsharedSecrete { get; set; }

    public bool? EnableJwtsecurity { get; set; }

    public bool? IsPublic { get; set; }

    public string? ApplicationUrl { get; set; }

    public string? ConnectionString { get; set; }

    public bool IsLocked { get; set; }

    public string? Attributes { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ApplicationDomain { get; set; }
}
