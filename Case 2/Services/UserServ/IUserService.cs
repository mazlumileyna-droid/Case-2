using Case_2.Models;

namespace Case_2.Services.UserServ
{
    public interface IUserService
    {
        //-----------------Mock + Json------------------//
        //-----------------------------------------------//
        //---------------------------------------------//
        List<User> GetAllUsers();
        User Login(string email, string password);
        List<User> GetUsersByRole(Role role);

        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        //-------------------------------------------------//
        //------------------------------------------------//
        //-----------------DB----------------------------//
    }
}






   