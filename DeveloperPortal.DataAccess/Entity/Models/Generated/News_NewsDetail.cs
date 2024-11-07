using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class News_NewsDetail
{
    /// <summary>
    /// Primary Key of the table
    /// </summary>
    public int Id { get; set; }

    public int DisplayConfigId { get; set; }

    public string Title { get; set; } = null!;

    public string? Summary { get; set; }

    public string Detail { get; set; } = null!;

    public DateTime? PublishDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? IsActive { get; set; }

    public int? SubmittedBy { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public virtual News_DisplayConfig DisplayConfig { get; set; } = null!;
}
