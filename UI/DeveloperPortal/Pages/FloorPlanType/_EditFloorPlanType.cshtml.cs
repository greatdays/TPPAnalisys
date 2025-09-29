using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperPortal.Pages.FloorPlanType
{
    [Authorize]
    public class _EditFloorPlanTypeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
