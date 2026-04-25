using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage.LogInPage
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // ❗ kjo është më e rëndësishmja
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }
    }
}