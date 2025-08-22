using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Dashboard
{
    public class DashboardDataModel
    {
        public string Type { get; set; }
        public string CaseId { get; set; }
        public string SiteCases { get; set; }
        public string ComplianceMatrixLink { get; set; }
        public string PropertyDetailsLink { get; set; }
        public string Status { get; set; }
        public string AssigneeID { get; set; }
        public string Summary { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAddress { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string AcHPFileProjectNumber { get; set; }
        public string ProblemProject { get; set; }
        public string OccpancyType { get; set; }
        public int NoofSites { get; set; }
        public int TotalUnits { get; set; }
        public string ReviewNoteAcHPFileProjectNumber { get; set; }

    }
}
