using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Common
{
    public class FileActivityWorkLogModel
    {
        public int WorkLogID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectSiteID { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public string WorkLog { get; set; }
        public string CreatedBy { get; set; }
        public List<string> Changes = new List<string>();
        public string FileNames { get; set; }
        public string PrimaryKey { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string SystemDescription { get; set; }
        public string Comments { get; set; }
        public string PropertyName { get; set; }
        public string SubmittedBy { get; set; }
        public string SubmittedDate { get; set; }
        public string FileType { get; set; }
    }
}
