using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.PropertySnapshot
{
    public static class Constants
    {
        #region AAHP Case Types

        //Case Types
        public const string RehabProject = "Sub Rehab Project";

        public const string RehabSite = "Sub Rehab Site";
        public const string NewConstructionProject = "New Construction Project";
        public const string OtherAlterationsProject = "Other Alterations Project";
        public const string NewConstructionSite = "New Construction Site";
        public const string OtherAlterationsSite = "Other Alterations Site";
        public const string Rehab_NewConstructionProject = "Sub Rehab/New Construction Project";
        public const string Rehab_NewConstructionSite = "Sub Rehab/New Construction Site";
        public const string RetrofitProject = "Retrofit Project";
        public const string RetrofitProjectSite = "Retrofit Site";
        public const string ExistingProject = "Existing Project";
        public const string ExistingProjectSite = "Existing Site";
        public const string RetrofitBidPackage = "Retrofit Bid Package";
        public const string RetrofitInvoice = "Retrofit Invoice";
        public const string PolicyProject = "Policy Project";
        public const string PolicySite = "Policy Site";
        public const string PropertyListing = "Property Listing";
        public const string HRMApplication = "HRM Application";
        public const string Grievance = "Grievance";
        public const string PMP = "PMP";
        public const string QR = "Quarterly Report";
        public const string ModularProject = "New Construction/Modular Project";
        public const string ModularSite = "New Construction/Modular Site";
        public const string Enforcement = "Enforcement";
        public const string CAP = "CAP";
        public const string BackgroundCheck = "Background Check";
        public const string GrievanceAppeal = "Grievance Appeal";
        public const string SubRehabRetrofitProject = "Sub Rehab/Retrofit Project";
        public const string SubRehabRetrofitSite = "Sub Rehab/Retrofit Site";
        public const string NewConstructionRetrofitProject = "New Construction/Retrofit Project";
        public const string NewConstructionRetrofitSite = "New Construction/Retrofit Site";

        #endregion AAHP Case Types

        #region IdentifierType

        public const string IdentifierTypeProjectSite = "ProjectSite";
        public const string IdentifierTypeProject = "Project";
        public const string IdentifierTypeBuilding = "Building";
        #endregion IdentifierType

        #region Service Request number Generator Types

        //Case number Types
        public const string CNTRetrofitProject = "CRFP";

        public const string CNTRehabProject = "CRBP";
        public const string CNTNewConstructionProject = "CNCP";
        public const string CNTOtherAlterationsProject = "COAP";
        public const string CNTRetrofitSite = "CRFS";
        public const string CNTRehabSite = "CRBS";
        public const string CNTNewConstructionSite = "CNCS";
        public const string CNTOtherAlterationsSite = "COAS";
        public const string CNTBidPackage = "CRFB";
        public const string CNTInvoice = "CRFI";
        public const string CNTRehabNCProject = "CRNP";
        public const string CNTRehabNCSite = "CRNS";
        public const string CNTPolicyProject = "CPOP";
        public const string CNTPolicySite = "CPOS";
        public const string CNTPropertyListing = "HRL";
        public const string CNTDefault = "AAHP";
        public const string CNTHRMApplication = "HR";
        public const string CNTGrievance = "GR";
        public const string CNTPMP = "PMP";
        public const string CNTQR = "QR";
        public const string CNTModularProject = "CNMP";
        public const string CNTEnforcementProject = "N";
        public const string CNTModularSite = "CNMS";
        public const string CNTCAPProject = "CAP";
        public const string CNTBG = "BG";
        public const string CNTGrievanceAppeal = "GA";
        public const string CNTSubRehabRetrofitProject = "CRRP";
        public const string CNTSubRehabRetrofitSite = "CRPS";
        public const string CNTNewConstructionRetrofitProject = "CNRP";
        public const string CNTNewConstructionRetrofitSite = "CNRS";
        #endregion Service Request number Generator Types

        #region WorkFlow Action Name

        public const string WFNACActionName = "Submit NAC Report";
        public const string WFApproveResearch = "Approve Research";
        public const string WFMarkInfeasible = "Mark Infeasible";
        public const string WFApproveNacSurveyReport = "Approve NAC survey report";
        public const string WFIssueCorrections = "Issue Corrections";
        public const string WFPassInspection = "Pass Inspection";
        public const string WFCompleteProgressInspections = "Complete progress inspections";
        public const string WFCompleteFinalAcHPInspections = "Complete Final AcHP inspections";
        public const string WFScheduleProgressInspection = "Schedule Progress Inspection";
        public const string WFScheduleFinalAcHPInspection = "Schedule Final AcHP Inspection";
        public const string WFScheduleFinalNACInspection = "Schedule Final NAC Inspection";

        #endregion WorkFlow Action Name

        #region Contact Types
        public const int ApplicantConactType = 42;
        public const int ClientConactType = 44;
        #endregion

        #region Projectsite Status
        public const string ResearchVerified = "Research Verified";
        public const string ApprovedForInitialNacScheduling = "Approved for Initial NAC Scheduling";
        public const string DeemedInfeasible = "Deemed Infeasible";
        public const string ClosedInfeasible = "Closed - Infeasible";
        public const string ScopeofWorkandBidPackageinProgress = "Scope of Work and Bid Package in Progress";
        public const string FinalNACInspectionCorrectionsIssued = "Final NAC Inspection Corrections Issued";
        public const string UnderRCSIIIreview = "Under RCSIII Review";
        public const string InitialNACSurveyReportApproved = "Initial NAC Survey Report Approved";
        public const string AwardContract = "Award Contract";
        public const string ProgressInspectionScheduled = "Progress Inspection Scheduled";
        public const string FinalAcHPInspectionScheduled = "Final AcHP Inspection Scheduled";
        public const string NTPIssued = "NTP Issued";
        public const string Approved = "Approved";
        public const string FinalAcHPInspectionCompleted = "Final AcHP Inspection Completed";
        public const string FinalAcHPInspectionApproved = "Final AcHP Inspection Approved";
        public const string FinalNACInspectionScheduled = "Final NAC Inspection Scheduled";
        public const string NACVerificationApproved = "NAC Verification Approved";
        public const string NACVerificationofComplianceApproved = "NAC Verification of Compliance Approved";
        public const string Closed = "Closed";

        #endregion Projectsite Status

        #region Project Status
        public const string InitialNACSurveyReportUnderReview = "Initial NAC Survey Report Under Review";
        public const string WF_Status_Scope_of_Bid_Package = "Scope of Work and Bid Package in Progress";
        public const string WF_Status_DeemInfeasible = "Deemed Infeasible";
        public const string WF_Status_Close_Infeasible = "Closed - Infeasible";
        public const string WF_Status_InitialNACReport = "Initial NAC Survey Report Under Review";
        public const string WF_Status_InitialNACSurveyApproved = "Initial NAC Survey Report Approved";
        public const string WF_Status_UnderConstruction = "Under Construction";
        public const string WF_Status_ProgressInspectionCompleted = "Progress Inspection Completed";
        public const string WF_Status_FinalAcHPInspectionCompleted = "Final AcHP Inspection Completed";
        public const string WF_Status_ReadyForDesignReview = "Ready for Design Review";
        #endregion Project Status

        #region Bid Package Constant
        public const string ContractAwarded = "Contract Awarded";
        public const string BidPackageCancelled = "Bid Package Cancelled";
        #endregion Bid Package Constant


        public class WorkFlowStateName
        {
            #region AAHP WorkFlow Action Name

            public const string ClosedCompliant = "Closed - Compliant";
            public const string Closed = "Closed";
            public const string ClosedInfeasible = "Closed - Infeasible";
            public const string ApproveInitialNACSurvey = "Approve NAC survey report";
            public const string CreateBidPackage = "Create scope of work and Bid Package";
            //added for Policy Compliance
            public const string AuditCompleted = "Audit Completed";
            public const string Cancelled = "Cancelled";
            public const string CertifiedCompliance = "Certified Compliance";
            #endregion AAHP WorkFlow Action Name
        }

        public class ListingType
        {
            #region Listing Type
            public const int IsCityConvenant = 1;
            public const int IsNonCityConvenant = 2;
            public const int IsNotConvenant = 3;
            #endregion
        }

        public class AccessibilityComplianceStatus
        {
            #region Listing Type
            public const string Unverified = "Unverified";
            public const string PendingCertification = "Pending Certification";
            public const string Certified = "Certified";
            #endregion
        }

        public class TypeOfConstruction
        {
            public const string NewConstruction = "New Construction";
            public const string OtherAlterations = "Other Alterations";
            public const string SubRehab = "Sub Rehab";
            public const string SubRehab_NewConstruction = "Sub Rehab/New Construction";
            public const string Retrofit = "Retrofit";
            public const string Existing = "Existing";
            public const string NewConstruction_Modular = "New Construction/Modular";

        }
    }
}
