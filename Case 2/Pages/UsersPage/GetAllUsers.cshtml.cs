using Case_2.Models;
using Case_2.Services.UserServ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Case_2.Pages.UsersPage

{ 
        [Authorize(Roles = "Admin")]
        public class GetAllUsersModel : PageModel
        {
            private readonly IUserService _userService;

            public GetAllUsersModel(IUserService userService)
            {
                _userService = userService;
            }

        public List<User> Users { get; set; } = new List<User>();

        public void OnGet(string role)
        {
            if (role == "Student")
                Users = _userService.GetUsersByRole(Role.Student);

            else if (role == "Teacher")
                Users = _userService.GetUsersByRole(Role.Teacher);

            else
                Users = _userService.GetAllUsers(); 
        }
    }
    }
    
