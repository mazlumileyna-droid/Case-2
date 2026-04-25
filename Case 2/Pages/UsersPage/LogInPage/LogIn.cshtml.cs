using Case_2.Models;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage.LogInPage
{
    public class LogInModel : PageModel
    {

        private readonly IUserService _userService;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public Role Role { get; set; }

        public string Error { get; set; }

        public LogInModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet(Role role)
        {
            Role = role;
        }

        public IActionResult OnPost()
        {
            try
            {
                var user = _userService.Login(Email, Password);

                if (user.Role != Role)
                    throw new Exception("Wrong role");

                //  LOGIN 
                HttpContext.Session.SetString("IsLoggedIn", "true");

             
                if (user.Role == Role.Admin)
                    return RedirectToPage("/UsersPage/Admin/GetAllUsers");

                if (user.Role == Role.Student)
                    return RedirectToPage("/UsersPage/Student");

                if (user.Role == Role.Teacher)
                    return RedirectToPage("/UsersPage/Teacher");

                return Page();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return Page();
            }
        }
    }
    
}