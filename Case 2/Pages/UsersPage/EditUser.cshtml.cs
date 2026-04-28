using Case_2.Models;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage
{
    public class EditUserModel : PageModel
    {
    
        private readonly IUserService _userService;

        public EditUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet(int id)
        {
            User = _userService.GetAllUsers()
                .FirstOrDefault(u => u.UserId == id);
        }

        public IActionResult OnPost()
        {
            _userService.UpdateUser(User);

            return RedirectToPage("/UsersPage/GetAllUsers");
        }
    }
}

