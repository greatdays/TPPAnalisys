using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Grievance
{
    public int GrievanceId { get; set; }

    public long ServiceRequestId { get; set; }

    public string? GrievantFirstName { get; set; }

    public string? GrievantMiddleName { get; set; }

    public string? GrievantLastName { get; set; }

    public string? GrievantPrimaryPhone { get; set; }

    public string? GrievantPrimaryLutPhoneTypeCd { get; set; }

    public string? GrievantAltPhone { get; set; }

    public string? GrievantAltLutPhoneTypeCd { get; set; }

    public string? GrievantEmail { get; set; }

    public string? GrievantLanguage { get; set; }

    public bool? IsGrievantPreferredContactEmail { get; set; }

    public bool? IsGrievantPreferredContactPhone { get; set; }

    public bool? IsGrievantPreferredContactTty { get; set; }

    public bool? IsGrievantPreferredContactUsmail { get; set; }

    public string? GrievantPreferredContactMethodOther { get; set; }

    public bool? IsGrievantAddressPobox { get; set; }

    public int? GrievantAddressHouseNum { get; set; }

    public string? GrievantAddressHouseFracNum { get; set; }

    public string? GrievantAddressLutPreDirCd { get; set; }

    public string? GrievantAddressStreetName { get; set; }

    public string? GrievantAddressLutStreetTypeCd { get; set; }

    public string? GrievantAddressUnit { get; set; }

    public string? GrievantAddressCity { get; set; }

    public string? GrievantAddressLutStateCd { get; set; }

    public int? GrievantAddressZip { get; set; }

    public bool IsFileForSomeOne { get; set; }

    public string? PreparerRelationship { get; set; }

    public string? PreparerFirstName { get; set; }

    public string? PreparerMiddleName { get; set; }

    public string? PreparerLastName { get; set; }

    public string? PreparerPrimaryPhone { get; set; }

    public string? PreparerPrimaryLutPhoneTypeCd { get; set; }

    public string? PreparerAltPhone { get; set; }

    public string? PreparerAltLutPhoneTypeCd { get; set; }

    public string? PreparerEmail { get; set; }

    public bool? IsPreparerPreferredContactEmail { get; set; }

    public bool? IsPreparerPreferredContactPhone { get; set; }

    public bool? IsPreparerPreferredContactTty { get; set; }

    public bool? IsPreparerPreferredContactUsmail { get; set; }

    public string? PreparerPreferredContactMethodOther { get; set; }

    public bool? IsPreparerAddressPobox { get; set; }

    public int? PreparerAddressHouseNum { get; set; }

    public string? PreparerAddressHouseFracNum { get; set; }

    public string? PreparerAddressLutPreDirCd { get; set; }

    public string? PreparerAddressStreetName { get; set; }

    public string? PreparerAddressLutStreetTypeCd { get; set; }

    public string? PreparerAddressUnit { get; set; }

    public string? PreparerAddressCity { get; set; }

    public string? PreparerAddressLutStateCd { get; set; }

    public int? PreparerAddressZip { get; set; }

    public bool? IsIncidentSpecificLocation { get; set; }

    public bool? IsIncidentSameAddress { get; set; }

    public string? IncidentLocationName { get; set; }

    public int? IncidentAddressHouseNum { get; set; }

    public string? IncidentAddressHouseFracNum { get; set; }

    public string? IncidentAddressLutPreDirCd { get; set; }

    public string? IncidentAddressStreetName { get; set; }

    public string? IncidentAddressLutStreetTypeCd { get; set; }

    public string? IncidentAddressUnit { get; set; }

    public string? IncidentAddressCity { get; set; }

    public string? IncidentAddressLutStateCd { get; set; }

    public int? IncidentAddressZip { get; set; }

    public string? GrievanceDescription { get; set; }

    public bool? IsNoticeToVacateReceived { get; set; }

    public bool? IsUnlawfulDetainerReceived { get; set; }

    public bool? IsSheriffsNoticeReceived { get; set; }

    public DateTime? NoticeToVacateReceivedDate { get; set; }

    public bool? IsGivenMoveOutDate { get; set; }

    public DateTime? RequiredMoveOutDate { get; set; }

    public bool? IsUnitDenied { get; set; }

    public bool? IsUnitVacant { get; set; }

    public bool? IsUnitAccessible { get; set; }

    public int? LutGrievanceSourceId { get; set; }

    public int? LutGrievanceReferralAgencyId { get; set; }

    public int? AcHpemployeeId { get; set; }

    public string? AcHpemployeeUserName { get; set; }

    public string? AcHpemployeeName { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public Guid RowId { get; set; }

    public bool? IsGrievantSatisfied { get; set; }

    public bool? IsCoveredHousingDevelopment { get; set; }

    public bool? IsDisabilityRelated { get; set; }

    public int? LutGrievanceDeterminationId { get; set; }

    public DateTime? DateOfDetermination { get; set; }

    public string? ExplanationOfDetermination { get; set; }

    public string? PropertyActionOnGrievance { get; set; }

    public string? ReferralAgencyOther { get; set; }

    public string? MilestonesResolution { get; set; }

    public bool? IsFiledRelatedGrievance { get; set; }

    public bool? IsUnknownFiledRelatedGrievance { get; set; }

    public DateTime? RelatedGrievanceFiledDate { get; set; }

    public bool? IsUnknownRelatedGrievanceFiledDate { get; set; }

    public string? RelatedGrievanceQrgrievanceLogId { get; set; }

    public bool? IsUnknownRelatedGrievanceQrgrievanceLogId { get; set; }

    public bool? IsFiledWithAnotherOrg { get; set; }

    public bool? IsUnknownFiledWithAnotherOrg { get; set; }

    public bool? IsFiledWithCacivilRightsDept { get; set; }

    public string? FiledDatesCacivilRightsDept { get; set; }

    public bool? IsFiledWithCourt { get; set; }

    public string? FiledNameOfCourt { get; set; }

    public string? FiledDatesCourt { get; set; }

    public bool? IsFiledWithDeptOfFairEmplAndHousing { get; set; }

    public string? FiledDatesDeptOfFairEmplAndHousing { get; set; }

    public bool? IsFiledWithFairHousingOrg { get; set; }

    public string? FiledNameOfOrg { get; set; }

    public string? FiledDatesFairHousingOrg { get; set; }

    public bool? IsFiledWithHud { get; set; }

    public string? FiledDatesHud { get; set; }

    public bool? IsFiledWithOther { get; set; }

    public string? FiledDescOfOther { get; set; }

    public string? FiledDatesOther { get; set; }

    public virtual ICollection<AssnGrievanceMilestonesDate> AssnGrievanceMilestonesDates { get; set; } = new List<AssnGrievanceMilestonesDate>();

    public virtual ICollection<GrievanceLog1> GrievanceLog1s { get; set; } = new List<GrievanceLog1>();

    public virtual ICollection<GrievanceType> GrievanceTypes { get; set; } = new List<GrievanceType>();

    public virtual LutGrievanceDetermination? LutGrievanceDetermination { get; set; }

    public virtual LutGrievanceReferralAgency? LutGrievanceReferralAgency { get; set; }

    public virtual LutGrievanceSource? LutGrievanceSource { get; set; }

    public virtual ICollection<LutGrievanceReferralAgency> LutGrievanceReferralAgencies { get; set; } = new List<LutGrievanceReferralAgency>();
}
