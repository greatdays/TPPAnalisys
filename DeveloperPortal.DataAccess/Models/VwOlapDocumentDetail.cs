using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapDocumentDetail
{
    public int Id { get; set; }

    public int? ProjectSiteId { get; set; }

    public int? ProjectId { get; set; }

    public string? Category { get; set; }

    public string? SubCategory { get; set; }

    public string? OriginalFileName { get; set; }

    public string? UniqueId { get; set; }

    public string? Received { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public string? MimeType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedOn { get; set; }

    public string? Description { get; set; }
}
