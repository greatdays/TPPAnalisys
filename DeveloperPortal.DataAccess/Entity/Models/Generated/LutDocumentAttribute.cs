using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class LutDocumentAttribute
{
    public int LutDocumentAttributeId { get; set; }

    public string AttributeName { get; set; } = null!;

    /// <summary>
    /// Comma seperated possible value for the attribute
    /// </summary>
    public string AttributeValue { get; set; } = null!;

    /// <summary>
    /// Created By
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Modified By
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified On
    /// </summary>
    public DateTime? ModifiedOn { get; set; }
}
