using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class AssnDocumentSubCategoryStatus
{
    public int Id { get; set; }

    public int SubCategoryId { get; set; }

    public int DocumentStatusId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual LutDocumentCategory DocumentStatus { get; set; } = null!;

    public virtual LutDocumentCategory SubCategory { get; set; } = null!;
}
