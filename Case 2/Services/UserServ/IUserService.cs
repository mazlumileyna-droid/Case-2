using Case_2.Models;

namespace Case_2.Services.UserServ
{
    public interface IUserService
    {
        User Register(User user);
        User Login(string email, string password);
        User GetUserById(int id);
        List<User> GetAllUsers();
        void DeleteUser(int id);
        List<User> GetUsersByRole(Role role);
    }
}
