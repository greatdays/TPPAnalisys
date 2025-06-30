using System;

namespace DeveloperPortal.DataAccess.Entity.EntityModels
{
    public class AngelenoUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
