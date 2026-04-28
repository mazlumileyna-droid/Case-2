using Case_2.Models;
using Microsoft.AspNetCore.Identity;

namespace Case_2.Mock
{
    public class MockUsers
    {
        //private static List<User> _users = new List<User>
        //{
        //    new User(1, "Sona", "sad004@edu.zealand.dk", "1234", Role.Student),
        //    new User(2, "John", "john@zealand.dk", "1234", Role.Teacher),
        //    new User(3, "Admin", "admin@gmail.com", "admin", Role.Admin)
        //};


        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> _users = new List<User>
{
    new User(1, "Sona", "sad004@edu.zealand.dk",
        passwordHasher.HashPassword(null, "1234"), Role.Student),

    new User(2, "John", "john@zealand.dk",
        passwordHasher.HashPassword(null, "1234"), Role.Teacher),

    new User(3, "Admin", "admin@gmail.com",
        passwordHasher.HashPassword(null, "admin"), Role.Admin)
};
        public static List<User> GetMockUsers()
        {
            return _users;
        }
    }
}