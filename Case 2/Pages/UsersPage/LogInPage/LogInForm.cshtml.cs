using Case_2.Models;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Case_2.Pages.UsersPage.LogInPage
{
    public class LogInFormModel : PageModel
    {
        private readonly IUserService _userService;

        public string Message { get; set; }

        public LogInFormModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty(SupportsGet = true)]
        public Role Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _userService.Login(Email, Password);

            if (user == null)
            {
                Message = "Invalid email or password";
                return Page();
            }

            if (user.Role != Role)
            {
                Message = "Wrong login type selected!";
                return Page();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(ClaimTypes.Role, user.Role.ToString())
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (user.Role == Role.Admin)
                return RedirectToPage("/UsersPage/LogInPage/AdminDashBoard");

            return RedirectToPage("/LokalePage/GetAllLokale");
        }
    }
}