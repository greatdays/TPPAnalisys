using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class vwAcHPDataForHHH
{
    public string? HIMSNumber { get; set; }

    public string? ProjectName { get; set; }

    public string? PropertyAddress { get; set; }

    public string Currently_Occupied_or_Not_Occupied { get; set; } = null!;

    public string Site_Visit_Date { get; set; } = null!;

    public DateTime? Policy_Compliance_Review_Date { get; set; }

    public string? Property_Management_Plan__PMP____Updated_2020 { get; set; }

    public DateOnly? Date_City_Certification_Issued { get; set; }
}
