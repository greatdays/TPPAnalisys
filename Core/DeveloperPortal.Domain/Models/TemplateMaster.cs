using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class TemplateMaster
{
    public int Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public bool IsHeader { get; set; }

    public int NoOfColumn { get; set; }

    public bool IsFooter { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TabMaster> TabMasters { get; set; } = new List<TabMaster>();

    public virtual ICollection<TemplateDetail> TemplateDetails { get; set; } = new List<TemplateDetail>();
}
