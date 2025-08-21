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
        
        public const string SP_uspRoGetConstructionCaseDetail = "AAHPCC.uspRoGetConstructionCaseDetail";
        public const string SP_uspGetDMSDocumentDetails = "DMS.uspGetDMSDocumentDetails";
        public const string SP_uspGetDMSFolderDetails = "DMS.uspGetDMSFolderDetails";

    }
}
