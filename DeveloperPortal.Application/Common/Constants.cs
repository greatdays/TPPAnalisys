using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.Common
{
    public static class StoredProcedureNames
    {
        public const string SP_uspRoGetAllConstructionCases = "AAHPCC.uspRoGetAllConstructionCases";
        public const string SP_uspRoGetAllConstructionCasesForDevelopmentPortal = "AAHPCC.uspRoGetAllConstructionCasesForDevelopmentPortal";
        public const string SP_uspRoGetReviewNoteACHPFileNumber = "AAHPCC.uspRoGetReviewNoteACHPFileNumber";
        public const string SP_uspRoGetReviewNoteForProject = "AAHPCC.uspRoGetReviewNoteByProject";

        public const string SP_uspRoGetConstructionCaseDetail = "AAHPCC.uspRoGetConstructionCaseDetail";
        public const string SP_uspGetDMSDocumentDetails = "DMS.uspGetDMSDocumentDetails";
        public const string SP_uspGetDMSFolderDetails = "DMS.uspGetDMSFolderDetails";
        public const string SP_uspRoGetAllProjectParticipantsForTPP = "AAHR.uspRoGetAllProjectParticipantsForTPP";

    }

    

    public static class ConstAssnPropContact
    {
        public const string Project = "Project";
        public const string Status = "Pending Approval";
        public const string Source = "AAHRDeveloperPortal";
        public const string Role = "Developer";
    }
}
