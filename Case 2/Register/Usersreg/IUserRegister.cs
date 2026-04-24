using Case_2.Models;

namespace Case_2.Register.Usersreg
{
   
   public interface IUserRegister
    {
        User FindById(int id);
        User FindByEmail(string email);
        List<User> FindAll();
        User Save(User user);
        void Delete(int id);
    }
}
