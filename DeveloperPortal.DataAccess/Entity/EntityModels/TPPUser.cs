using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Entity.EntityModels
{
    public class TPPUser
    {
        public int UserId { get; set; }      
        public string Email { get; set; }      
        public string Provider { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
