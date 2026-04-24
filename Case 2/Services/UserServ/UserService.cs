using Case_2.Models;
using Case_2.Register.Usersreg;

namespace Case_2.Services.UserServ
{

    public class UserService : IUserService
    {
        private IUserRegister _userRegister;

        // Constructor
        public UserService(IUserRegister userRegister)
        {
            _userRegister = userRegister;
        }

        // REGISTER USER
        public User Register(User user)
        {
            // check if email already exists
            var existingUser = _userRegister.FindByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            ValidateEmailByRole(user);

            _userRegister.Save(user);
            return user;
        }

        // LOGIN USER
        public User Login(string email, string password)
        {
            var user = _userRegister.FindByEmail(email);

            if (user == null || user.Password != password)
            {
                throw new Exception("Invalid email or password");
            }

            return user;
        }


        private void ValidateEmailByRole(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || !user.Email.Contains("@"))
                throw new Exception("Invalid email");

            var email = user.Email.ToLower();

            if (user.Role == Role.Student)
            {
                if (!email.EndsWith("@edu.zealand.dk"))
                    throw new Exception("Student must have edu email");
            }

            if (user.Role == Role.Teacher)
            {
                if (!email.EndsWith("@zealand.dk") || email.Contains("@edu."))
                    throw new Exception("Teacher must have @zealand.dk email (not edu)");
            }

           
        }


        // GET USER BY ID
        public User GetUserById(int id)
        {
            return _userRegister.FindById(id);
        }


        // GET ALL USERS
        public List<User> GetAllUsers()
        {
            return _userRegister.FindAll();
        }

        public List<User> GetUsersByRole(Role role)
        {
            return _userRegister.FindAll()
                .Where(u => u.Role == role)
                .ToList();
        }

        // DELETE USER
        public void DeleteUser(int id)
        {
            _userRegister.Delete(id);
        }
    }
}