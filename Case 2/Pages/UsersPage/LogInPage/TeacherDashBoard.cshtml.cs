using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage.LogInPage
{
    public class TeacherDashBoardModel : PageModel
    {

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Teacher")
            {
                return RedirectToPage("/UsersPage/LogInPage/LogIn");
            }

            return Page();
        }
    }
}