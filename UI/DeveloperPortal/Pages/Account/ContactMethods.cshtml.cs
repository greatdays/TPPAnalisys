using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.Account
{
    public class ContactMethodsModel : PageModel
    {
        public string PhoneType { get; set; }
        public void OnGet()
        {
            //PhoneType.
        }
    }
}
