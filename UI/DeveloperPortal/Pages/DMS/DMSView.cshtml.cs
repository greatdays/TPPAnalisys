using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.DMS
{
    [Authorize]
    public class DMSViewModel : PageModel
    {
        public void OnGet()
        {
            // Initial load — nothing needed here
        }
    }
}
