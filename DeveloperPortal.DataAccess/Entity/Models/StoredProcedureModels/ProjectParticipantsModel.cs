using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels
{
    public class ProjectParticipantsModel
    {
        public int ProjectSiteId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string TeamRole { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
