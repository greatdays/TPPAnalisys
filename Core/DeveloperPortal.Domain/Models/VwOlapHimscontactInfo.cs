using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class VwOlapHimscontactInfo
{
    public string FullProjectNumber { get; set; } = null!;

    public int ProjUniqueId { get; set; }

    public string ApplicantOrBorrower { get; set; } = null!;

    public string? ParticipantType { get; set; }

    public string? Address { get; set; }

    public string ContactPerson { get; set; } = null!;

    public string BusPhone { get; set; } = null!;

    public string CellPhone { get; set; } = null!;

    public string? Pname { get; set; }

    public int? ContactPersonId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? ParticipantId { get; set; }

    public string? Modified { get; set; }
}
