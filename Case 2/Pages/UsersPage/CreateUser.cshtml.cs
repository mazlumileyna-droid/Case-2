using Case_2.Models;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage
{
    public class CreateUserModel : PageModel
  
    {
        private readonly IUserService _userService;

        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
            User = new User();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            //  Student
            if (User.Role == Role.Student &&
                !User.Email.ToLower().EndsWith("@edu.zealand.dk"))
            {
                ModelState.AddModelError("", "Studerende skal have en email der slutter med @edu.zealand.dk");
                return Page();
            }

            //  Teacher
            if (User.Role == Role.Teacher &&
                !User.Email.ToLower().EndsWith("@zealand.dk"))
            {
                ModelState.AddModelError("", "Undervisere skal have en email der slutter med @zealand.dk");
                return Page();
            }

            _userService.CreateUser(User);

            return RedirectToPage("/UsersPage/GetAllUsers");
        }
    }
}

