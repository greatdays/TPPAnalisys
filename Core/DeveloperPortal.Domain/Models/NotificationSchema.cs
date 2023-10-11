using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class NotificationSchema
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<AssnActionSchemaTemplate> AssnActionSchemaTemplates { get; set; } = new List<AssnActionSchemaTemplate>();
}
