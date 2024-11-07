using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class GrievanceAppeal
{
    public int GrievanceAppealID { get; set; }

    public long ServiceRequestID { get; set; }

    public string? GrievantFirstName { get; set; }

    public string? GrievantMiddleName { get; set; }

    public string? GrievantLastName { get; set; }

    public string? GrievantPrimaryPhone { get; set; }

    public string? GrievantPrimaryLutPhoneTypeCD { get; set; }

    public string? GrievantAltPhone { get; set; }

    public string? GrievantAltLutPhoneTypeCD { get; set; }

    public string? GrievantEmail { get; set; }

    public string? GrievantLanguage { get; set; }

    public bool? IsGrievantPreferredContactEmail { get; set; }

    public bool? IsGrievantPreferredContactPhone { get; set; }

    public bool? IsGrievantPreferredContactTTY { get; set; }

    public bool? IsGrievantPreferredContactUSMail { get; set; }

    public string? GrievantPreferredContactMethodOther { get; set; }

    public bool? IsGrievantAddressPOBox { get; set; }

    public int? GrievantAddressHouseNum { get; set; }

    public string? GrievantAddressHouseFracNum { get; set; }

    public string? GrievantAddressLutPreDirCD { get; set; }

    public string? GrievantAddressStreetName { get; set; }

    public string? GrievantAddressLutStreetTypeCD { get; set; }

    public string? GrievantAddressUnit { get; set; }

    public string? GrievantAddressCity { get; set; }

    public string? GrievantAddressLutStateCD { get; set; }

    public int? GrievantAddressZip { get; set; }

    public bool IsFileForSomeOne { get; set; }

    public string? PreparerRelationship { get; set; }

    public string? PreparerFirstName { get; set; }

    public string? PreparerMiddleName { get; set; }

    public string? PreparerLastName { get; set; }

    public string? PreparerPrimaryPhone { get; set; }

    public string? PreparerPrimaryLutPhoneTypeCD { get; set; }

    public string? PreparerAltPhone { get; set; }

    public string? PreparerAltLutPhoneTypeCD { get; set; }

    public string? PreparerEmail { get; set; }

    public bool? IsPreparerPreferredContactEmail { get; set; }

    public bool? IsPreparerPreferredContactPhone { get; set; }

    public bool? IsPreparerPreferredContactTTY { get; set; }

    public bool? IsPreparerPreferredContactUSMail { get; set; }

    public string? PreparerPreferredContactMethodOther { get; set; }

    public bool? IsPreparerAddressPOBox { get; set; }

    public int? PreparerAddressHouseNum { get; set; }

    public string? PreparerAddressHouseFracNum { get; set; }

    public string? PreparerAddressLutPreDirCD { get; set; }

    public string? PreparerAddressStreetName { get; set; }

    public string? PreparerAddressLutStreetTypeCD { get; set; }

    public string? PreparerAddressUnit { get; set; }

    public string? PreparerAddressCity { get; set; }

    public string? PreparerAddressLutStateCD { get; set; }

    public int? PreparerAddressZip { get; set; }

    public bool? IsIncidentSpecificLocation { get; set; }

    public bool? IsIncidentSameAddress { get; set; }

    public string? IncidentLocationName { get; set; }

    public int? IncidentAddressHouseNum { get; set; }

    public string? IncidentAddressHouseFracNum { get; set; }

    public string? IncidentAddressLutPreDirCD { get; set; }

    public string? IncidentAddressStreetName { get; set; }

    public string? IncidentAddressLutStreetTypeCD { get; set; }

    public string? IncidentAddressUnit { get; set; }

    public string? IncidentAddressCity { get; set; }

    public string? IncidentAddressLutStateCD { get; set; }

    public int? IncidentAddressZip { get; set; }

    public string? GrievanceDescription { get; set; }

    public bool? IsNoticeOfDeterminationeReceived { get; set; }

    public DateOnly? NoticeOfDeterminationReceivedDate { get; set; }

    public bool? IsGrievanceAgainstOwnerPM { get; set; }

    public bool? IsGrievanceAgainstLAHD { get; set; }

    public string? GrievanceDecisionDisagreeReason { get; set; }

    public int? LutGrievanceAppealSourceID { get; set; }

    public int? AcHPEmployeeID { get; set; }

    public string? AcHPEmployeeUserName { get; set; }

    public string? AcHPEmployeeName { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowID { get; set; }

    public string? ReferralAgencyOther { get; set; }

    public string? MilestonesResolution { get; set; }

    public virtual LutGrievanceSource? LutGrievanceAppealSource { get; set; }

    public virtual ICollection<LutGrievanceReferralAgency> LutGrievanceReferralAgencies { get; set; } = new List<LutGrievanceReferralAgency>();
}
