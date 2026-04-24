using Case_2.Models;
using Case_2.Register.Usersreg;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage.Admin.GetAll
{
    public class GetAllUsersModel : PageModel
    {
        private IUserService _userService;

        public List<User> Users { get; set; }

        public GetAllUsersModel()
        {
            _userService = new UserService(new UserRegister());
        }

        public void OnGet()
        {
            Users = _userService.GetAllUsers();   // ⭐ KJO ËSHTË
        }
    }
}
