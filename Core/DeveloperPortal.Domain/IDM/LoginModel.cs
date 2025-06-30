using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Domain.IDM
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
