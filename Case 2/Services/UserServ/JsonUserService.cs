using Case_2.Mock;
using Case_2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Case_2.Services.UserServ


{
    public class JsonUserService : IUserService
    {


        private readonly JsonFileService _json;

        public JsonUserService(JsonFileService json)
        {
            _json = json;

            var users = MockUsers.GetMockUsers(); // tager users med hash+  
            _json.SaveAll(users); // +og så gemmer i JSON
        }

        public List<User> GetAllUsers()
        {
            return _json.GetAll();
        }

        public List<User> GetUsersByRole(Role role)
        {
            return _json.GetAll()
                .Where(u => u.Role == role)
                .ToList();
        }

        public User Login(string email, string password)
        {
            var user = _json.GetAll()
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher<string>();

            var result = passwordHasher.VerifyHashedPassword(
                null,
                user.Password,
                password
            );

            if (result == PasswordVerificationResult.Success)
                return user;

            return null;
        }

        public void CreateUser(User user)   //Auto ++ ID 
        {
            var users = _json.GetAll();

            user.UserId = users.Any()
                ? users.Max(u => u.UserId) + 1
                : 1;

            users.Add(user);

            _json.SaveAll(users);
        }

        public void UpdateUser(User user)
        {
            var users = _json.GetAll();

            var existing = users.FirstOrDefault(u => u.UserId == user.UserId);

            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
                existing.Password = user.Password;
                existing.Role = user.Role;
            }

            _json.SaveAll(users);
        }

        public void DeleteUser(int id)
        {
            var users = _json.GetAll();

            var user = users.FirstOrDefault(u => u.UserId == id);

            if (user != null)
                users.Remove(user);

            _json.SaveAll(users);
        }
    }
}