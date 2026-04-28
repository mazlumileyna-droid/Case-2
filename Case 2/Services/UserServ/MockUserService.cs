using Case_2.Mock;
using Case_2.Models;

namespace Case_2.Services.UserServ
{
    public class MockUserService : IUserService
    {
        private List<User> _users = MockUsers.GetMockUsers();
    
            public List<User> GetAllUsers()
        {
            return _users;
        }
        public User Login(string email, string password)
        {
            var users = GetAllUsers();

            return users.FirstOrDefault(u =>
                u.Email == email && u.Password == password);
        }
        public List<User> GetUsersByRole(Role role)
        {
            return _users
                .Where(u => u.Role == role)
                .ToList();
        }


        public void CreateUser(User user)
        {
            user.UserId = _users.Max(u => u.UserId) + 1;
            _users.Add(user);
        }

     
        public void UpdateUser(User user)
        {
            var existing = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
                existing.Password = user.Password;
                existing.Role = user.Role;
            }
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
                _users.Remove(user);
        }
    }
}


