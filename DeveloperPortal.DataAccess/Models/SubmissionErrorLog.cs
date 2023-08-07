using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class SubmissionErrorLog
{
    public int Id { get; set; }

    public string? ModuleName { get; set; }

    public int? ProjectSiteId { get; set; }

    public string? ErrorMessage { get; set; }

    public string? ErrorLine { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }
}
