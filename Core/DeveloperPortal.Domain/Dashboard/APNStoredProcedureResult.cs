using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.Dashboard
{
    public class APNStoredProcedureResult
    {
        public int Success { get; set; }
        public int ProjectID { get; set; }
        public int ProjectSiteID { get; set; }
        public long ProjectServiceRequestID { get; set; }
        public long SiteServiceRequestID { get; set; }
        public string FileGroup { get; set; }
    }
}
