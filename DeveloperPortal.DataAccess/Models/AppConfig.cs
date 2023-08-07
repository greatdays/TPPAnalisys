using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class AppConfig
{
    public int AppConfigId { get; set; }

    public int ApplicationId { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ApplicationMaster Application { get; set; } = null!;
}
