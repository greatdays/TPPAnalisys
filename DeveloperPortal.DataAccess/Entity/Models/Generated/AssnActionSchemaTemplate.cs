using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnActionSchemaTemplate
{
    public int ActionId { get; set; }

    public int SchemaId { get; set; }

    public int TemplateId { get; set; }

    public virtual WfAction Action { get; set; } = null!;

    public virtual NotificationSchema Schema { get; set; } = null!;

    public virtual NotificationTemplate Template { get; set; } = null!;
}
