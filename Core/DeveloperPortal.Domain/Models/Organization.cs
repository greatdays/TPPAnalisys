using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string? Name { get; set; }

    public string? LegalName { get; set; }

    public string? CensoredName { get; set; }

    public string? BusinessLicense { get; set; }

    public DateTime? LicenseValidFrom { get; set; }

    public DateTime? LicenseValidTo { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? PhoneFax { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public string? PictureThumbnail { get; set; }

    public string? PictureMain { get; set; }

    public string? IdmuserName { get; set; }

    public bool IsReviewRequired { get; set; }

    public string? Source { get; set; }

    public string? Status { get; set; }

    public string? Attributes { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Tty { get; set; }

    public string? Description { get; set; }

    public string? WebSite { get; set; }

    public string? ServiceProvided { get; set; }

    public string? AreaServed { get; set; }

    public string? EmailDomain { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AssnOrganizationContact> AssnOrganizationContacts { get; set; } = new List<AssnOrganizationContact>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<OrganizationAddress> OrganizationAddresses { get; set; } = new List<OrganizationAddress>();

    public virtual ICollection<PmpoutreachOrganisation> PmpoutreachOrganisations { get; set; } = new List<PmpoutreachOrganisation>();

    public virtual ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();

    public virtual ICollection<TrainingRegistry> TrainingRegistries { get; set; } = new List<TrainingRegistry>();
}
