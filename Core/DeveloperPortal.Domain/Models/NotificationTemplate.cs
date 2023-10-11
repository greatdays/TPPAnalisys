using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class NotificationTemplate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? EmailSubject { get; set; }

    public string? EmailBody { get; set; }

    public string? Parameters { get; set; }

    public virtual ICollection<AssnActionSchemaTemplate> AssnActionSchemaTemplates { get; set; } = new List<AssnActionSchemaTemplate>();

    public virtual ICollection<BatchJobDetail> BatchJobDetails { get; set; } = new List<BatchJobDetail>();
}
