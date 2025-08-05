using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class MyAccountModel : PageModel
    {

        [BindProperty]
        public MyAccountViewModel Account { get; set; }

        public void OnGet()
        {
            // Load mock data
            Account = new MyAccountViewModel
            {
                FirstName = "Mike",
                MiddleName = "",
                LastName = "Taylor",
                Email = "sumer.singh@lacity.org",
                PhoneType = "Mobile",
                PhoneNumber = "(213)213-0289",
                Extension = "2452",
                CompanyName = "Company Name",
                Title = "Title",
                ArchitecturalLicenseNumber = "1234567899841285469",
                HasPOBox = false,
                StreetNumber = "123",
                StreetDirection = "N",
                StreetName = "Main St",
                StreetType = "Avenue",
                UnitNumber = "101",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90001"
            };
        }
        public JsonResult OnPostUpdate([FromBody] MyAccountViewModel data)
        {
            // Simulate update success
            return new JsonResult(new
            {
                success = true,
                message = "Your account has been updated!",
                data=data
            });
        }
    }
    public class MyAccountViewModel
    {
        [Required] public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required] public string LastName { get; set; }

        [Required, EmailAddress] public string Email { get; set; }

        [Required] public string PhoneType { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public string Extension { get; set; }

        [Required] public string CompanyName { get; set; }
        [Required] public string Title { get; set; }

        [Required] public string ArchitecturalLicenseNumber { get; set; }

        [Required] public bool HasPOBox { get; set; }

        [Required] public string StreetNumber { get; set; }
        public string StreetDirection { get; set; }
        [Required] public string StreetName { get; set; }

        [Required] public string StreetType { get; set; }
        public string UnitNumber { get; set; }

        [Required] public string City { get; set; }
        [Required] public string State { get; set; }
        [Required] public string ZipCode { get; set; }
    }

}
