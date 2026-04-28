//using Case_2.Models;
//using Case_2.Register.Usersreg;

//namespace Case_2.Services.UserServ
//{
//    public class UserService : IUserService
//    {
//        private IUserRegister _userRegister;

//        public UserService(IUserRegister userRegister)
//        {
//            _userRegister = userRegister;
//        }

//        // REGISTER
//        public User Register(User user)
//        {
//            var existingUser = _userRegister.FindByEmail(user.Email);

//            if (existingUser != null)
//                throw new Exception("User already exists");

//            ValidateEmailByRole(user);

//            return _userRegister.Save(user);
//        }

//        // LOGIN
//        public User Login(string email, string password)
//        {
//            var user = _userRegister.FindByEmail(email);

//            if (user == null || user.Password != password)
//                throw new Exception("Invalid email or password");

//            return user;
//        }

//        // VALIDIM EMAIL
//        private void ValidateEmailByRole(User user)
//        {
//            if (string.IsNullOrEmpty(user.Email) || !user.Email.Contains("@"))
//                throw new Exception("Invalid email");

//            var email = user.Email.ToLower();

//            if (user.Role == Role.Student)
//            {
//                if (!email.EndsWith("@edu.zealand.dk"))
//                    throw new Exception("Student must have edu email");
//            }

//            if (user.Role == Role.Teacher)
//            {
//                if (!email.EndsWith("@zealand.dk") || email.Contains("@edu."))
//                    throw new Exception("Teacher must have @zealand.dk email");
//            }
//        }

      
//        public User GetUserById(int id)
//        {
//            return _userRegister.FindById(id);
//        }

//        public List<User> GetAllUsers()
//        {
//            return _userRegister.FindAll();
//        }


//        // UPDATE
//        public User UpdateUser(User user)
//        {
//            return _userRegister.Update(user);
//        }

//        // DELETE
//        public void DeleteUser(int id)
//        {
//            _userRegister.Delete(id);
//        }


//        public List<User> GetUsersByRole(Role role)
//        {
//            return _userRegister.FindAll()
//                .Where(u => u.Role == role)
//                .ToList();
//        }
//    }
//}