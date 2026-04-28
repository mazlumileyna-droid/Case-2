using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage.LogInPage
{
    

    [Authorize(Roles = "Admin")]

    public class AdminDashBoardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
