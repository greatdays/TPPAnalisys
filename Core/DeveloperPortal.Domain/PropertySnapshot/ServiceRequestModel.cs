using DeveloperPortal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.PropertySnapshot
{
    public class ServiceRequestModel : AuditModel
    {
        public long ServiceRequestId { get; set; }

        public int CaseId { get; set; }

        public int ServiceRequestTypeId { get; set; }

        public string ServiceRequestNumber { get; set; }

        public string ServiceTrackingId { get; set; }

        public int? ProgramCycleId { get; set; }

        public int? ComplianceStatusId { get; set; }

        public int? InspectionStatusId { get; set; }

        public bool? IsLocked { get; set; }

        public int PropSnapshotId { get; set; }

        public int CaseTypeId { get; set; }

        public string Status { get; set; }

        public string SiteAddress { get; set; }

        public string APN { get; set; }

        public string ServiceRequestAttributes { get; set; }
        public string CaseType { get; set; }

        public string APNAttributes { get; set; }
        public int? RefProjectID { get; set; }

        public string UnitCount { get; set; }
        public int? RefProjectSiteID { get; set; }

        public int? ProjectID { get; set; }
        public string IdentifierType { get; set; }
        public int? ProjectSiteID { get; set; }
        public List<InspectionModel> InspectionDetails { get; set; }

        public string ProjectName { get; set; }
        public string FileNumber { get; set; }
        public string CESType { get; set; }

        public string ServiceRequestComments { get; set; }
    }
}
