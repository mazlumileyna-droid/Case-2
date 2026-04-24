using Case_2.Models;
using Case_2.Register.Usersreg;

namespace Case_2.Register.Usersreg
{

    public class UserRegister : IUserRegister
    {
        private List<User> _users = new List<User>
{
    new User(1, "Sara", "sad004@edu.zealand.dk", "1234", Role.Student),
    new User(2, "John", "john@zealand.dk", "1234", Role.Teacher),
    new User(3, "Admin", "admin@gmail.com", "admin", Role.Admin)
};

        public User Save(User user)
        {
            _users.Add(user);
            return user;
        }
        public User FindByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public User FindById(int id)
        {
            return _users.FirstOrDefault(u => u.UserId == id);
        }

    
        public List<User> FindAll()
        {
            return new List<User>(_users);
        }

     

        public void Delete(int id)
        {
            var user = FindById(id);
            if (user != null)
                _users.Remove(user);
        }
    }
}