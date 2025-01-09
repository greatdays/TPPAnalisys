using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.Models.IDM
{
    public class ApplicationDetail
    {
        public int ApplicationId { get; set; }
        public string AppKey { get; set; }
        public string AppName { get; set; }
        public string ApplicationURL { get; set; }
        public string JWTAccessCode { get; set; }
        public string JWTToken { get; set; }
        public List<string> Roles { get; set; }
        public string ConnectionString { get; set; }
        public string Attributes { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAppAssociated { get; set; }
    }
}
