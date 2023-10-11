using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwDmsdocument
{
    public int Id { get; set; }

    public int? EntryId { get; set; }

    public string? PrimaryKey { get; set; }

    public string? Category { get; set; }

    public string? SubCategory { get; set; }

    public string? OriginalFileName { get; set; }

    public string? Description { get; set; }

    public string? UniqueId { get; set; }

    public string? Received { get; set; }

    public string? Status { get; set; }

    public string? Audience { get; set; }

    public string? HimsNumber { get; set; }

    public string? AcHpNumber { get; set; }

    public string? CaseId { get; set; }

    public string? SystemDescription { get; set; }

    public string? Apn { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public string? LastAccessed { get; set; }

    public string? HimsProjectId { get; set; }

    public string? AcHpProjectId { get; set; }

    public string? AcHpPropertyId { get; set; }

    public string? DefaultImage { get; set; }

    public string? ViewOrder { get; set; }

    public string? FileExtension { get; set; }

    public string? FileSize { get; set; }

    public string? InternalUrl { get; set; }

    public string? MimeType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedOn { get; set; }
}
