using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwOLAP_DocumentDetail
{
    public int id { get; set; }

    public int? ProjectSiteID { get; set; }

    public int? ProjectID { get; set; }

    public string? Category { get; set; }

    public string? Sub_Category { get; set; }

    public string? Original_File_Name { get; set; }

    public string? UniqueId { get; set; }

    public string? Received { get; set; }

    public string? Status { get; set; }

    public string? Created_By { get; set; }

    public string? Modified_By { get; set; }

    public string? MimeType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedOn { get; set; }

    public string? Description { get; set; }

    public string? AcHP_Number { get; set; }
}
